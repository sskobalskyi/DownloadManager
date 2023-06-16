using DownloadManager.Contracts.Enums;
using DownloadManager.Contracts.Models;
using DownloadManager.Contracts.Requests;
using DownloadManager.Services.Interfaces;

namespace DownloadManager.Services.Services
{
    internal sealed class DownloadService : IDownloadService
    {
        private readonly IDownloadsManager _downloadManager;

        public DownloadService(HttpClient httpClient, IDownloadsManager downloadManager)
        {
            _downloadManager = downloadManager;
        }
        public DownloadModel AddDownload(AddDownloadRequest request)
        {
            var downloadModel = new DownloadModel
            {
                DownloadSpeed = DownloadSpeed.Slow,
                DownloadStatus = DownloadStatus.Active,
                File = new FileModel()
                {
                    FileName = request.FileName,
                    Path = request.Uri
                },
                Url = request.Url
            };

            _downloadManager.AddToQueue(downloadModel, request.cancellationToken);

            Thread.Sleep(500);

            return downloadModel;
        }
        public Task<DownloadModel> PauseDownload()
        {
            throw new NotImplementedException();
        }

        public Task<DownloadModel> RemoveDownload()
        {
            throw new NotImplementedException();
        }

        public Task<DownloadModel> ResumeDownload()
        {
            throw new NotImplementedException();
        }
    }
}
