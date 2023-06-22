namespace DownloadManger.Core.Repositories
{
    public interface ISettingsRepository
    {
        Task<bool> SetMaxSimultaneousDownloads(int maxSimultaneousDownloads);
        Task<bool> SetPreferedStorage(int preferedStorage);
        Task<int> GetMaxSimultaneousDownloads();
        Task<int> GetPreferedStorage();
    }
}
