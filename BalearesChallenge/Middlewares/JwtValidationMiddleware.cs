using Domain.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BalearesChallengeApi.Middlewares
{
    public class JwtValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JWTSettings _jwtSettings;
        public JwtValidationMiddleware(RequestDelegate next, IOptions<JWTSettings> jwtSettings)
        {
            _next = next;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var authorizeAttribute = endpoint?.Metadata?.GetMetadata<AuthorizeAttribute>();

            // Si la acción tiene el atributo [Authorize], se procede con la validación del token.
            if (authorizeAttribute != null)
            {
                var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

                if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Falta el token o es inválido.");
                    return;
                }

                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                try
                {

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };

                    var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                    if (validatedToken is JwtSecurityToken jwtToken)
                    {
                        // Verificar si el token ha expirado
                        var expirationDate = jwtToken.ValidTo;
                        if (expirationDate < DateTime.UtcNow)
                        {
                            context.Response.StatusCode = 401; // Unauthorized
                            await context.Response.WriteAsync("Token Expirado.");
                            return;
                        }
                    }


                    context.User = principal;
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("El Token es invalido.");
                    return;
                }
            }

            await _next(context);
        }
    }

}
