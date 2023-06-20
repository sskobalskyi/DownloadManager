using DownloadManger.Core.Entities;
using DownloadManger.Core.Repositories;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonwloadManager.Persistance.Firebase
{
    public sealed class FirebaseDbClient : IHistoryRepository
    {
        private readonly IFirebaseClient _client;
        public FirebaseDbClient(IOptions<FirebaseSettings> settings)
        {
            _client = new FirebaseClient(new FirebaseConfig()
            {
                BasePath = settings.Value.BasePath,
                AuthSecret = settings.Value.AuthSecret,
            });
        }

        public async Task<List<Download>> GetDonwloadsAsync()
        {
            var response = await _client.GetAsync("downloads/");

            if (response.Body != null)
            {
                var dictionary = response.ResultAs<Dictionary<string, Download>>();

                var result = new List<Download>();
                
                foreach (var item in dictionary)
                {
                    result.Add(item.Value);
                }

                return result;
            }

            return null;
        }

        public async Task<bool> SaveToHistory(Download data)
        {
            try
            {
                var response = await _client.PushAsync("downloads/", data);
               
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                throw;
            }
        }
    }
}
