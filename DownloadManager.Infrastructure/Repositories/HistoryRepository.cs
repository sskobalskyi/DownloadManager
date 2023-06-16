using DownloadManger.Core.Entities;
using DownloadManger.Core.Repositories;

namespace DownloadManager.Infrastructure.Repositories
{
    internal sealed class HistoryRepository : IHistoryRepository
    {
        public Task<List<Donwload>> GetDonwloadsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Donwload> SaveToHistory()
        {
            throw new NotImplementedException();
        }
    }
}
