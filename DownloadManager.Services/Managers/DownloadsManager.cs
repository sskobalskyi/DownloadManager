using DownloadManager.Contracts.Models;
using DownloadManager.Services.Helpers;
using DownloadManager.Services.Interfaces;
using System.Collections.Concurrent;

namespace DownloadManager.Services.Managers
{
    public class DownloadsManager : IDownloadsManager
    {
        private readonly SemaphoreSlim downloadSemaphore = new SemaphoreSlim(3, 5);
        private readonly HttpClient _httpClient;
        private bool _workerStarted = false;
        private List<ThrottledStream> _streamPool;
        private ConcurrentQueue<DownloadModel> _queue;
        private int _poolSize = 3;

        public DownloadsManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _streamPool = new List<ThrottledStream>();
            _queue = new ConcurrentQueue<DownloadModel>();
        }

        public List<ThrottledStream>? StreamPool { get => _streamPool; }
        public ConcurrentQueue<DownloadModel>? Queue { get => _queue; }
        public int PoolSize
        {
            get => _poolSize;
            set
            {
                if (value > 0)
                    _poolSize = value;
            }
        }
        public void AddToQueue(DownloadModel model, CancellationToken cancellationToken)
        {
            _queue.Enqueue(model);

            if (!_workerStarted)
            {
                StartDownloadWorker();
            }
        }

        public async Task StartDownload(DownloadModel model)
        {

            var throttledStream = new ThrottledStream(_httpClient.GetStreamAsync(model.Url ?? "").Result, 1024);

            _streamPool.Add(throttledStream);

            using (var fs = new FileStream($"D:/pet/DownloadManager/downloads/{model.File?.FileName}", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                await throttledStream.CopyToAsync(fs);
            }
        }

        public void StartDownloadWorker()
        {
            _workerStarted = true;

            Task.Run(async () =>
            {
                while (_queue.TryDequeue(out var downloadModel))
                {

                    await downloadSemaphore.WaitAsync();

                    if (_poolSize <= 0)
                    {
                        downloadSemaphore.Release();
                        continue;
                    }

                    _poolSize--;
                    downloadSemaphore.Release();

                    await StartDownload(downloadModel);

                   downloadSemaphore.Wait();
                    _poolSize++;
                    downloadSemaphore.Release();
                }

                _workerStarted = false;
            });
        }

        public void StopDownload()
        {
        }

        public void PauseDownload()
        {
        }
    }
}