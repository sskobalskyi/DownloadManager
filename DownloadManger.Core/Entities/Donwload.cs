using DownloadManger.Core.Enums;

namespace DownloadManger.Core.Entities
{
    public class Donwload
    {
        int Id { get; set; }
        public File? File { get; set; }
        public string? Url { get; set; }
        public DownloadSpeed? DownloadSpeed { get; set; }
        public DownloadStatus? DownloadStatus { get; set; }
    }
}
