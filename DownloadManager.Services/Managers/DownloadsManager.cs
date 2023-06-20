using DownloadManager.Contracts.Requests;
using DownloadManager.Services.Helpers;
using DownloadManager.Services.Interfaces;
using DownloadManger.Core.Entities;
using DownloadManger.Core.Repositories;
using Microsoft.Extensions.Options;

namespace DownloadManager.Services.Managers
{
    public class DownloadsManager : IDownloadsManager
    {
        private readonly Semaphore _semaphore;
        private readonly IHistoryRepository _historyService;
        private readonly IOptions<DownloadSettings> configurationManager;
        private readonly HttpClient _httpClient;
        public DownloadsManager(HttpClient httpClient, IHistoryRepository historyService, IOptions<DownloadSettings> configurationManager)
        {
            _semaphore = new Semaphore(configurationManager.Value.MaxSimultaneousDownloads, configurationManager.Value.MaxSimultaneousDownloads);
            _httpClient = httpClient;
            _historyService = historyService;
            this.configurationManager = configurationManager;
        }

        public async void InitiateDownloading(List<AddDownloadRequest> models)
        {
            var downloads = new List<Task<Download>>();

            foreach (var model in models)
            {
                downloads.Add(StartDownload(model));
            }

            var results = await Task.WhenAll(downloads);

            foreach (var download in results)
            {
                _ = await _historyService.SaveToHistory(download);
            }
        }

        private async Task<Download> StartDownload(AddDownloadRequest model)
        {
            _semaphore.WaitOne();

            try
            {
                var throttledStream = new ThrottledStream(_httpClient.GetStreamAsync(model.Url ?? "").Result, configurationManager.Value.SlowDownloadSpeed);

                using (var fs = new FileStream($"D:/pet/DownloadManager/downloads/{model.Filename}", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await throttledStream.CopyToAsync(fs);

                    _semaphore.Release(configurationManager.Value.MaxSimultaneousDownloads);

                    return new Download()
                    {
                        Url = model.Url,
                        IsDownloaded = true,
                        WhenAdded = DateTime.Now
                    };
                }
            }
            catch (Exception e)
            {
                return new Download()
                {
                    Url = model.Url,
                    IsDownloaded = false,
                    WhenAdded = DateTime.Now
                };

                throw e;
            }
        }
    }
}