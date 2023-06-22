namespace DownloadManager.Contracts.Requests
{
    public sealed record class UpdateMaxSimultaneousDownloadsRequest
    {
        public UpdateMaxSimultaneousDownloadsRequest(int maxSimultaneousDownloads)
        {
            MaxSimultaneousDownloads = maxSimultaneousDownloads;
        }
        public int MaxSimultaneousDownloads { get; set; }
    }
}
