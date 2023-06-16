using DownloadManager.Services.Interfaces;
using DownloadManager.Services.Managers;
using DownloadManager.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DownloadManager.Services
{
    public static class ServicesStartup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<DownloadsManager>();
            services.AddSingleton<IDownloadsManager, DownloadsManager>();
            services.AddScoped<IDownloadService, DownloadService>();
        }
    }
}
