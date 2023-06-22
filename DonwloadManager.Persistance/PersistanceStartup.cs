using DownloadManager.Persistance.Firebase;
using DownloadManager.Persistance.LocalStorage;
using DownloadManger.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DownloadManager.Persistance
{
    public static class PersistanceStartup
    {
        public static void AddApplicationPersistanceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FirebaseSettings>(configuration.GetSection(nameof(FirebaseSettings)));

            services.AddTransient<IHistoryRepository, FirebaseHistoryRepository>();
            services.AddTransient<IHistoryRepository, LocalHistoryStorage>();
            services.AddTransient<ISettingsRepository, FirebaseSettingsRepository>();
        }
    }
}
