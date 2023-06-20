namespace DownloadManger.Core.Entities
{
    public class Download
    {
        public string? Url { get; set; }
        public bool IsDownloaded { get; set; }
        public DateTime? WhenAdded { get; set; }
    }
}
