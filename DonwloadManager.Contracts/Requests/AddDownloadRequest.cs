using DownloadManager.Contracts.Enums;

namespace DownloadManager.Contracts.Requests
{
    public class AddDownloadRequest
    {
        public string? Url { get; set; }
        public string? Filename { get; set; }
        public DownloadSpeed? DownloadSpeed { get; set; }
        public DownloadStatus? DownloadStatus { get; set; }
    }
}
