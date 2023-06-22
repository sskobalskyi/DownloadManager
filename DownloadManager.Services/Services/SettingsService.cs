using DownloadManager.Services.Interfaces;
using DownloadManger.Core.Repositories;

namespace DownloadManager.Services.Services
{
    internal sealed class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public Task<bool> SetMaxSimultaneousDownloads(int maxSimultaneousDownloads)
        {
            return _settingsRepository.SetMaxSimultaneousDownloads(maxSimultaneousDownloads);
        }

        public Task<bool> SetPreferedStorage(int preferedStorage)
        {
            return _settingsRepository.SetPreferedStorage(preferedStorage);
        }

        public async Task<int> GetPreferedStorage()
        {
            return await _settingsRepository.GetPreferedStorage();
        }

        public async Task<int> GetMaxSimultaneousDownloads()
        {
            return await _settingsRepository.GetMaxSimultaneousDownloads();
        }
    }
}

