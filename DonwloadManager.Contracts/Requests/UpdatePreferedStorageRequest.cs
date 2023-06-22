namespace DownloadManager.Contracts.Requests
{
    public sealed record UpdatePreferedStorageRequest
    {
        public UpdatePreferedStorageRequest(int preferedStorage)
        {
            PreferedStorage = preferedStorage;
        }
        public int PreferedStorage { get; set; }
    }
}
