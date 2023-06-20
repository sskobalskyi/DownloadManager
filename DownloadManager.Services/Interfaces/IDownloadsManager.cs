using DownloadManager.Contracts.Requests;

namespace DownloadManager.Services.Interfaces
{
    public interface IDownloadsManager
    {
        public void InitiateDownloading(List<AddDownloadRequest> models);
    }
}
