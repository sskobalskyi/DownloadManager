using DownloadManager.Contracts.Models;
using DownloadManager.Contracts.Requests;

namespace DownloadManager.Services.Interfaces
{
    public interface IDownloadService
    {
        DownloadModel AddDownload(AddDownloadRequest request);
        Task<DownloadModel> PauseDownload();
        Task<DownloadModel> ResumeDownload();
        Task<DownloadModel> RemoveDownload();
    }
}
