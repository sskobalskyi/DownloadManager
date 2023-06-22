using FireSharp.Config;
using FireSharp;
using FireSharp.Interfaces;
using Microsoft.Extensions.Options;

namespace DownloadManager.Persistance.Firebase
{
    public class FirebaseRepositoryBase
    {
        private readonly IFirebaseClient _client;

        public FirebaseRepositoryBase(IOptions<FirebaseSettings> settings)
        {
            _client = new FirebaseClient(new FirebaseConfig()
            {
                BasePath = settings.Value.BasePath,
                AuthSecret = settings.Value.AuthSecret,
            });
        }

        public IFirebaseClient Client => _client;
    }
}
