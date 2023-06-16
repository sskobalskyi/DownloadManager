using DownloadManager.Contracts.Requests;
using DownloadManager.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DownloadManager.Presentation.Modules
{
    public static class DonwloadModule
    {
        public static void AddDownloadModule(this IEndpointRouteBuilder app)
        {
            app.MapPost("/addDownload", ([FromBody]AddDownloadRequest request, [FromServices]IDownloadService downloadService) =>
            {
                downloadService.AddDownload(request);
            }).WithName("/addDownload");

            app.MapPost("/pauseDownload", () =>
            {
            }).WithName("/pauseDonload");

            app.MapPost("/removeDownload", () =>
            {
            }).WithName("/removeDonload");
        }
    }
}
