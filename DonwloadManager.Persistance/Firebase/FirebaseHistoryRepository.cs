using DownloadManger.Core.Entities;
using DownloadManger.Core.Repositories;
using FireSharp.Config;
using FireSharp;
using FireSharp.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DownloadManager.Persistance.Firebase
{
    public sealed class FirebaseHistoryRepository : IHistoryRepository
    {
        private readonly IFirebaseClient _client;

        public FirebaseHistoryRepository(IOptions<FirebaseSettings> settings)
        {
            _client = new FirebaseClient(new FirebaseConfig()
            {
                BasePath = "https://downloadmanager-c2bc6-default-rtdb.firebaseio.com",
                AuthSecret = "LYkF9txAUzN3kOwDb3OzgMaSVyF5wlaV9KU2mdoL",
            });
        }

        public async Task<List<Download>> GetDonwloads()
        {
            var response = await _client.GetAsync("downloads/");

            if (response.Body != null)
            {
                var dictionary = response.ResultAs<Dictionary<string, Download>>();

                var result = new List<Download>();

                if(dictionary == null)
                {
                    return result;
                }
                
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
