using Microsoft.AspNetCore.Builder;
using Rudy.WebAPI.Middleware;

namespace Rudy.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
