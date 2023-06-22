namespace DownloadManager.Services.Interfaces
{
    public interface ISettingsService
    {
        Task<bool> SetMaxSimultaneousDownloads(int maxSimultaneousDownloads);
        Task<bool> SetPreferedStorage(int preferedStorage);
        Task<int> GetPreferedStorage();
        Task<int> GetMaxSimultaneousDownloads();
    }
}
