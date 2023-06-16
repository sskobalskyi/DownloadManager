using DownloadManager.Contracts.Models;

namespace DownloadManager.Services.Interfaces
{
    public interface IDownloadsManager
    {
        public void AddToQueue(DownloadModel stream, CancellationToken cancellationToken);
        public void StopDownload();
        public void PauseDownload();
    }
}
