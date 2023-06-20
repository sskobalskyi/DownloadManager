using DownloadManager.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DownloadManager.Presentation.Modules
{
    public static class HistoryModule
    {
        public static void AddHistoryModule(this IEndpointRouteBuilder app)
        {
            app.MapGet("/getDownloadHistory", ([FromServices] IHistoryService downloadService) =>
            {
                return downloadService.GetDownLoads();
            }).WithName("/getgetDownloadHistory");
        }
    }
}
