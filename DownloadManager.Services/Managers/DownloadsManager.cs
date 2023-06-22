using DownloadManager.Contracts.Requests;
using DownloadManager.Services.Helpers;
using DownloadManager.Services.Interfaces;
using DownloadManger.Core.Entities;
using Microsoft.Extensions.Options;

namespace DownloadManager.Services.Managers
{
    public class DownloadsManager : IDownloadsManager
    {
        private readonly IHistoryService _historyService;
        private readonly ISettingsService _settingsService;
        private readonly HttpClient _httpClient;
        private readonly IOptions<DownloadSettings> _options;
        private Semaphore _semaphore;
        private int _maxSimultaneousDownloads;

        public DownloadsManager(HttpClient httpClient, IHistoryService historyService, ISettingsService settingsService, IOptions<DownloadSettings> options)
        {
            _settingsService = settingsService;
            _httpClient = httpClient;
            _historyService = historyService;
            _options = options;
        }

        public Semaphore Semaphore
        {
            get => _semaphore;
            private set
            {
                _semaphore = value;
            }
        }
        public int MaxSimultaneousDownloads
        {
            get { return _maxSimultaneousDownloads; }
            set { _maxSimultaneousDownloads = value;}
        }
        public HttpClient Client { get => _httpClient; }

        public async void InitiateDownloading(List<AddDownloadRequest> models)
        {
            MaxSimultaneousDownloads = await GetMaxSimultaneousSetting();

            Semaphore = new Semaphore(MaxSimultaneousDownloads, MaxSimultaneousDownloads);

            var downloads = new List<Task<Download>>();

            foreach (var model in models)
            {
                downloads.Add(StartDownload(model));
            }

            var results = await Task.WhenAll(downloads);

            foreach (var download in results)
            {
                _ = await _historyService.AddToHistoty(download);
            }
        }

        private async Task<Download> StartDownload(AddDownloadRequest model)
        {

            _semaphore.WaitOne();

            int downloadSpeed;

            if (model.DownloadSpeed == 0)
            {
                downloadSpeed = _options.Value.FastDownloadSpeed;
            }
            else
            {
                downloadSpeed = _options.Value.SlowDownloadSpeed;
            }

            var throttledStream = new ThrottledStream(Client.GetStreamAsync(model.Url ?? "").Result, downloadSpeed);
            
            try
            {
                using (var fs = new FileStream($"D:/pet/DownloadManager/downloads/{model.Filename}", FileMode.CreateNew, FileAccess.Write, FileShare.Read))
                {
                    await throttledStream.CopyToAsync(fs);

                    _semaphore.Release(1);

                    return new Download()
                    {
                        Url = model.Url,
                        IsDownloaded = true,
                        WhenAdded = DateTime.Now
                    };
                }
            }
            catch(Exception ex)
            {
                return new Download()
                {
                    Url = model.Url,
                    IsDownloaded = false,
                    WhenAdded = DateTime.Now
                };

                throw ex;
            }
        }

        private async Task<int> GetMaxSimultaneousSetting()
        {
            return await _settingsService.GetMaxSimultaneousDownloads();
        }
    }
}