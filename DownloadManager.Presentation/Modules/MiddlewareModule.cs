using DownloadManager.Presentation.Middleware;
using Microsoft.AspNetCore.Builder;

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
