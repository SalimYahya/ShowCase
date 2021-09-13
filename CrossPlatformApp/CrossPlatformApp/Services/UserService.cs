using CrossPlatformApp.DTO.Account;
using CrossPlatformApp.Models;
using CrossPlatformApp.Services.Contacts;
using CrossPlatformApp.Utils;
using CrossPlatformApp.Utils.Urls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CrossPlatformApp.Services
{
    public class UserService : IUserService
    {
        public const string TAG = nameof(UserService);
        HttpClient _httpClinet;

        public UserService()
        {
            _httpClinet = new HttpClient(HttpHandler
                .GetInstance()
                .GetInsecureHandler()
            );
        }

        public async Task<JwtToken> Login(Login login) 
        {
            JwtToken jwtToken = new JwtToken();

            var json = JsonConvert.SerializeObject(login);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClinet.PostAsync(ApiEndpoints.Account.Login, contentJson);


            var result = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine($"{TAG} - Response Content: {result.ToString()}");

            jwtToken = JsonConvert.DeserializeObject<JwtToken>(result);

            Debug.WriteLine($"{TAG} - Token-tostring: {jwtToken.ToString()}");

            await SecureStorage.SetAsync("jwtToken-token", jwtToken.Token);
            await SecureStorage.SetAsync("jwtToken-refresh-token", jwtToken.RefreshToken);
            await SecureStorage.SetAsync("jwtToken-epire-date", jwtToken.ExpireDate.ToString());

            //await SecureStorage.SetAsync("JwtToken", jwtToken);
            //Debug.WriteLine($"{TAG} - SecureTorage-JwtToken: {await SecureStorage.GetAsync("JwtToken")}");

            return jwtToken;

        }
    }
}


//Debug.WriteLine($"{TAG} - Token-Id: {jwtToken.Id}");
//Debug.WriteLine($"{TAG} - Token-tkn: {jwtToken.Token}, is Null: {jwtToken.Token == null}, is Emtpy: {jwtToken.Token.Equals("")}");
//Debug.WriteLine($"{TAG} - Token-rfsh: {jwtToken.RefreshToken}, is Null: {jwtToken.RefreshToken == null}, is Emtpy: {jwtToken.RefreshToken.Equals("")}");
//Debug.WriteLine($"{TAG} - Token-rfsh: { (string.IsNullOrEmpty(jwtToken.RefreshToken) ? "" : jwtToken.RefreshToken) }");

//Debug.WriteLine($"{TAG} - Token-success: {jwtToken.Success}");
//Debug.WriteLine($"{TAG} - Token-errors: {jwtToken.Errors}, is Null: {jwtToken.Errors == null}, is Emtpy: {jwtToken.Errors.Count == 0}");
//Debug.WriteLine($"{TAG} - Token-exdate: {jwtToken.ExpireDate}, is Null: {jwtToken.ExpireDate == null}");