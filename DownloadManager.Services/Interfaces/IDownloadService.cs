using DownloadManager.Contracts.Requests;

namespace DownloadManager.Services.Interfaces
{
    public interface IDownloadService
    {
        void AddDownload(List<AddDownloadRequest> request);
    }
}