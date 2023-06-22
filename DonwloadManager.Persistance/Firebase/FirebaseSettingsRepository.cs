using DownloadManager.Contracts.Requests;
using DownloadManger.Core.Repositories;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DownloadManager.Persistance.Firebase
{
    public class FirebaseSettingsRepository : ISettingsRepository
    {
        private readonly IFirebaseClient _client;

        public FirebaseSettingsRepository(IOptions<FirebaseSettings> settings)
        {
            _client = new FirebaseClient(new FirebaseConfig()
            {
                BasePath = "https://downloadmanager-c2bc6-default-rtdb.firebaseio.com",
                AuthSecret = "LYkF9txAUzN3kOwDb3OzgMaSVyF5wlaV9KU2mdoL",
            });
        }

        public async Task<bool> SetMaxSimultaneousDownloads(int maxSimultaneousDownloads)
        {
            var request = new UpdateMaxSimultaneousDownloadsRequest(maxSimultaneousDownloads)
            {
                MaxSimultaneousDownloads = maxSimultaneousDownloads
            };

            var response = await _client.UpdateAsync("Settings/", request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> SetPreferedStorage(int preferedStorage)
        {
            var request = new UpdatePreferedStorageRequest(preferedStorage)
            {
                PreferedStorage = preferedStorage
            };

            var response = await _client.UpdateAsync("Settings/", request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<int> GetMaxSimultaneousDownloads()
        {
            var response = await _client.GetAsync("Settings/");

            var dictionary = response.ResultAs<Dictionary<string, int>>();

            int result;

            dictionary.TryGetValue("MaxSimultaneousDownloads", out result);

            return result;
        }

        public async Task<int> GetPreferedStorage()
        {
            var response = await _client.GetAsync("Settings/");

            var dictionary = response.ResultAs<Dictionary<string, int>>();

            int result;

            dictionary.TryGetValue("PreferedStorage", out result);

            return result;
        }
    }
}
