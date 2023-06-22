using DownloadManger.Core.Entities;
using DownloadManger.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DownloadManager.Persistance.LocalStorage
{
    public sealed class LocalHistoryStorage : IHistoryRepository
    {
        private readonly string _localStoragePath;
        public LocalHistoryStorage(IConfiguration configuration)
        {
            _localStoragePath = configuration.GetValue<string>("localStoragePath");
        }

        public async Task<List<Download>> GetDonwloads()
        {
            string readContents;

            using (StreamReader streamReader = new StreamReader(_localStoragePath, Encoding.UTF8))
            {
                readContents = await streamReader.ReadToEndAsync();
            }
            
            var result = JsonSerializer.Deserialize<List<Download>>(readContents);

            return result;
        }

        public async Task<bool> SaveToHistory(Download data)
        {
            var serialized = JsonSerializer.Serialize(data);

            using (TextWriter tw = new StreamWriter(_localStoragePath, true, Encoding.UTF8))
            {
                await tw.WriteAsync(serialized);

                return true;
            }
        }
    }
}
