using DownloadManager.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DownloadManager.Presentation.Modules
{
    public static class SettingsModule
    {
        public static void AddConfigurationModule(this IEndpointRouteBuilder app)
        {
            app.MapPut("/setMaximumSimultaneous", async ([FromQuery]int maxSimultaneousDownloads, [FromServices] ISettingsService settingsService) =>
            {
                var res = await settingsService.SetMaxSimultaneousDownloads(maxSimultaneousDownloads);

                return res;
            }).WithName("setMaximumSimultaneous");

            app.MapPut("/setPreferedHistoryStorage", async ([FromQuery]int preferedStorage, [FromServices] ISettingsService settingsService) =>
            {
                var res = await settingsService.SetPreferedStorage(preferedStorage);

                return res;
            }).WithName("setPreferedHistoryStorage");
        }
    }
}
