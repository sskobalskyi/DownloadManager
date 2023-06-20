using DownloadManager.Services.Helpers;
using DownloadManager.Services.Interfaces;
using DownloadManager.Services.Managers;
using DownloadManager.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DownloadManager.Services
{
    public static class ServicesStartup
    {
        public static void AddApplicationServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHttpClient<DownloadsManager>();

            services.Configure<DownloadSettings>(configuration.GetSection(nameof(DownloadSettings)));
            services.Configure<StorageSettings>(configuration.GetSection(nameof(StorageSettings)));

            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<IDownloadService, DownloadService>();
            services.AddScoped<IDownloadsManager, DownloadsManager>();
        }
    }
}
