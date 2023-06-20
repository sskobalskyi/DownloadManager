using DownloadManger.Core.Entities;

namespace DownloadManger.Core.Repositories
{
    public interface IHistoryRepository
    {
        Task<List<Download>> GetDonwloadsAsync();
        Task<bool> SaveToHistory(Download data);
    }
}
