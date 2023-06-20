using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace DownloadManager.Presentation.Modules
{
    public static class ConfigurationModule
    {
        public static void AddConfigurationModule(this IEndpointRouteBuilder app)
        {
            app.MapPost("/setMaximumSimultaneous", () =>
            {
            }).WithName("setMaximumSimultaneous");

            app.MapPost("/setPreferedHistoryStorage", () =>
            {
            }).WithName("setPreferedHistoryStorage");
        }
    }
}
