using DownloadManager.Contracts.Requests;
using DownloadManager.Services.Interfaces;

namespace DownloadManager.Services.Services
{
    internal sealed class DownloadService : IDownloadService
    {
        private readonly IDownloadsManager _downloadManager;

        public DownloadService(IDownloadsManager downloadManager)
        {
            _downloadManager = downloadManager;
        }
        public void AddDownload(List<AddDownloadRequest> requests)
        {
            _downloadManager.InitiateDownloading(requests);
        }
    }
}
