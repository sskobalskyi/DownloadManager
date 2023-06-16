using DownloadManager.Contracts.Models;

namespace DownloadManager.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<DownloadModel>> GetDownLoads();
        Task<DownloadModel> AddToHistoty(DownloadModel model);
    }
}
