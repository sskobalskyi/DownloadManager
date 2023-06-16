using DownloadManager.Contracts.Enums;

namespace DownloadManager.Contracts.Models
{
    public class DownloadModel
    {
        int Id { get; set; }
        public FileModel? File { get; set; }
        public string? Url { get; set; }
        public DownloadSpeed? DownloadSpeed { get; set; }
        public DownloadStatus? DownloadStatus { get; set; }
    }
}
