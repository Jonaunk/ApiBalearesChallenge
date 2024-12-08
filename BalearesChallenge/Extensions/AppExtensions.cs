using BalearesChallengeApi.Middlewares;

namespace BalearesChallengeApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandleMiddleware>();
            app.UseMiddleware<JwtValidationMiddleware>();
        }

        public static void UseJwtValidationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtValidationMiddleware>();
        }
    }
}
