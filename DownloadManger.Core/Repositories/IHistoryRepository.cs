using DownloadManger.Core.Entities;

namespace DownloadManger.Core.Repositories
{
    public interface IHistoryRepository
    {
        Task<List<Donwload>> GetDonwloadsAsync();
        Task<Donwload> SaveToHistory();
    }
}
