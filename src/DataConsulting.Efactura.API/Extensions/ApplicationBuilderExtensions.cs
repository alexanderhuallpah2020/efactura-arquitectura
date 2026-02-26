using DataConsulting.Efactura.API.Middleware;

namespace DataConsulting.Efactura.API.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandler>();
        }

        internal static IApplicationBuilder UseLogContextTraceLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<LogContextTraceLoggingMiddleware>();

            return app;
        }
    }
}
