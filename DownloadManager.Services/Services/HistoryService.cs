using DownloadManager.Persistance.Firebase;
using DownloadManager.Persistance.LocalStorage;
using DownloadManager.Services.Enums;
using DownloadManager.Services.Interfaces;
using DownloadManger.Core.Entities;
using DownloadManger.Core.Repositories;

namespace DownloadManager.Services.Services
{
    internal sealed class HistoryService : IHistoryService
    {
        private readonly IEnumerable<IHistoryRepository> _repositories;
        private readonly ISettingsService _settingsService;

        public HistoryService(IEnumerable<IHistoryRepository> repositories, ISettingsService settingsService)
        {
            _repositories = repositories;
            _settingsService = settingsService;
        }

        public async Task<bool> AddToHistoty(Download model)
        {
            var _repository = await ResolveService();
            
            return await _repository.SaveToHistory(model);
        }

        public async Task<List<Download>> GetDownLoads()
        {
            var _repository = await ResolveService();

            return await _repository.GetDonwloads();
        }

        private async Task<IHistoryRepository> ResolveService()
        {
            var preferedStorageSetting = await _settingsService.GetPreferedStorage();

            var preferedStorage = (Storage)preferedStorageSetting;

            switch (preferedStorage)
            {
                case Storage.Firebase:
                    return _repositories.SingleOrDefault(s => s.GetType() == typeof(FirebaseHistoryRepository));
                case Storage.LocalStorage:
                    return _repositories.SingleOrDefault(s => s.GetType() == typeof(LocalHistoryStorage));
                default:
                    return _repositories.SingleOrDefault(s => s.GetType() == typeof(FirebaseHistoryRepository));
            }
        }
    }
}
