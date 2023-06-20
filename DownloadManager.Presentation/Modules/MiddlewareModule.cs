using DownloadManager.Presentation.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DownloadManager.Presentation.Modules
{
    public static class MiddlewareModule
    {
        public static void AddCustomMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
