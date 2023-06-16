using DownloadManager.Presentation.Middleware;
using Microsoft.AspNetCore.Builder;

namespace DownloadManager.Presentation.Modules
{
    public static class MiddlewareModule
    {
        public static void AddMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
