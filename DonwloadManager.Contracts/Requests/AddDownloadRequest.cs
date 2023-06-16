namespace DownloadManager.Contracts.Requests
{
    public class AddDownloadRequest
    {
        public string? Url { get; set; }
        public string? Uri { get; set; }
        public string? FileName { get; set; }
        public CancellationToken cancellationToken { get; set; }
    }
}
