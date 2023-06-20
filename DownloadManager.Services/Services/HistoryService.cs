using DonwloadManager.Persistance.Firebase;
using DonwloadManager.Persistance.LocalStorage;
using DownloadManager.Services.Enums;
using DownloadManager.Services.Helpers;
using DownloadManager.Services.Interfaces;
using DownloadManger.Core.Entities;
using DownloadManger.Core.Repositories;
using Microsoft.Extensions.Options;

namespace DownloadManager.Services.Services
{
    internal sealed class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _repository;

        public HistoryService(IEnumerable<IHistoryRepository> repositories, IOptions<StorageSettings> configurationManager)
        {
            var preferedStorage = configurationManager.Value.PreferedStorage;

            _repository = ResolveService(repositories, preferedStorage);
        }

        public Task<bool> AddToHistoty(Download model)
        {
            return _repository.SaveToHistory(model);
        }

        public Task<List<Download>> GetDownLoads()
        {
            return _repository.GetDonwloadsAsync();
        }

        private IHistoryRepository ResolveService(IEnumerable<IHistoryRepository> repositories, string preferedStorage)
        {
            if (preferedStorage == Storage.Firebase.ToString().ToLower())
            {
                return repositories.SingleOrDefault(s => s.GetType() == typeof(FirebaseDbClient));
            }
            else if(preferedStorage == Storage.LocalStorage.ToString().ToLower())
            {
                return repositories.SingleOrDefault(s => s.GetType() == typeof(LocalHistoryStorage));
            }

            return repositories.FirstOrDefault();
        }
    }
}
