namespace DownloadManager.Services.Helpers
{
    public sealed record DownloadSettings
    {
        public int FastDownloadSpeed { get; set; }
        public int SlowDownloadSpeed { get; set; }
        public int MaxSimultaneousDownloads { get; set; }
    }
}
