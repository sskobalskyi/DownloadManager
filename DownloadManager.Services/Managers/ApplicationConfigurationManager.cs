using DownloadManager.Services.Helpers;

namespace DownloadManager.Services.Managers
{
    public sealed class ApplicationConfigurationManager : IApplicationConfigurationManager
    {
        private readonly DownloadSettings _downloadSettings;
        private readonly StorageSettings _storageSettings;
        public ApplicationConfigurationManager(DownloadSettings downloadSettings, StorageSettings storageSettings)
        {
            _downloadSettings = downloadSettings;
            _storageSettings = storageSettings;
        }

        public DownloadSettings DownloadSettings => _downloadSettings;
        public StorageSettings StorageSettings => _storageSettings;
    }
}
