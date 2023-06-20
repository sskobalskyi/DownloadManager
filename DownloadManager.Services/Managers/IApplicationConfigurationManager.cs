using DownloadManager.Services.Helpers;

namespace DownloadManager.Services.Managers
{
    public interface IApplicationConfigurationManager
    {
        DownloadSettings DownloadSettings { get; }
        StorageSettings StorageSettings { get; }
    }
}