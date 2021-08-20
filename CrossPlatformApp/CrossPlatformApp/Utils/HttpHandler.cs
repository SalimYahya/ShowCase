using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CrossPlatformApp.Utils
{
    public class HttpHandler
    {
        public HttpClientHandler httpClientHandler;

        #region Singlton
        private HttpHandler() 
        {
            httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
        }

        private static HttpHandler _httpHandler;
        public  static HttpHandler GetInstance()
        {
            if (_httpHandler != null)
                return _httpHandler;

            _httpHandler = new HttpHandler();
            return _httpHandler;
        }
        #endregion


        public HttpClientHandler GetInsecureHandler() 
        {
            return httpClientHandler;
        }
    }
}
