using DownloadManager.Contracts.Models;
using DownloadManger.Core.Entities;

namespace DownloadManager.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<Download>> GetDownLoads();
        Task<bool> AddToHistoty(Download model);
    }
}
