using DownloadManger.Core.Entities;

namespace DownloadManger.Core.Repositories
{
    public interface IHistoryRepository
    {
        Task<List<Download>> GetDonwloads();
        Task<bool> SaveToHistory(Download data);
    }
}