using Application.Common.Exceptions;
using Application.Common.Wrappers;
using System.Net;
using System.Text.Json;

namespace BalearesChallengeApi.Middlewares
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Aca en el flujo si no hay error continua
                await _next(context);
            }
            catch (Exception error)
            {
                //Si hay error interceptamos la respuesta
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeded = false, Message = error?.Message };
                //La modificamos segun el error
                switch (error)
                {
                    case ApiException e:
                        //custom api error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationException e:
                        //custom error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        //not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        //unhandle error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                //Retornamos el error sobrescrito
                await response.WriteAsync(result);
            }
        }
    }
}
