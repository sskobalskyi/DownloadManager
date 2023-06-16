using DownloadManager.Contracts.Models;
using DownloadManager.Services.Interfaces;

namespace DownloadManager.Services.Services
{
    internal sealed class HistoryService : IHistoryService
    {
        public Task<DownloadModel> AddToHistoty()
        {
           return default (Task<DownloadModel>);
        }

        public Task<DownloadModel> AddToHistoty(DownloadModel model)
        {
            return default(Task<DownloadModel>);
        }

        public Task<List<DownloadModel>> GetDownLoads()
        {
            return default (Task<List<DownloadModel>>);
        }
    }
}
