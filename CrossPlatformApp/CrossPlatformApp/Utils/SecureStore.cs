using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CrossPlatformApp.Utils
{
    public class SecureStore
    {
        private static string _token = "JwtToken";

        public async Task StoreJwtTokenAsync(string token) 
        {
            await SecureStorage.SetAsync(_token, token);
        }

        public async Task<string> GetJwtTokenAsync() 
        {
            return await SecureStorage.GetAsync(_token);
        }

        public void DeleteJwtToken() 
        {
            SecureStorage.Remove(_token);
        }

        public void DeleteAll() 
        {
            SecureStorage.RemoveAll();
        }
    }
}
