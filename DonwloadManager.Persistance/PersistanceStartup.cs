using DonwloadManager.Persistance.Firebase;
using DonwloadManager.Persistance.LocalStorage;
using DownloadManger.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DonwloadManager.Persistance
{
    public static class PersistanceStartup
    {
        public static void AddApplicationPersistanceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FirebaseSettings>(configuration.GetSection(nameof(FirebaseSettings));

            services.AddTransient<IHistoryRepository, FirebaseDbClient>();
            services.AddTransient<IHistoryRepository, LocalHistoryStorage>();
        }
    }
}
