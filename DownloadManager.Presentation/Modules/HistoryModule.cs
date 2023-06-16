using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace DownloadManager.Presentation.Modules
{
    public static class HistoryModule
    {
        public static void AddHistoryModule(this IEndpointRouteBuilder app)
        {
            app.MapPost("/getActiveDownloads", () =>
            {
            }).WithName("/getActiveDownloads");

            app.MapPost("/getDownloadHistory", () =>
            {
            }).WithName("/getgetDownloadHistory");
        }
    }
}
