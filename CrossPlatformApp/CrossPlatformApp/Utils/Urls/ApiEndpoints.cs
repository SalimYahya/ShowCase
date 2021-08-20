using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformApp.Utils.Urls
{
    public static class ApiEndpoints
    {
        public const string BaseUrl = "https://10.0.2.2:5001/api/";

        #region Inner Classes
        public static class Account 
        {
            public const string Regiter = BaseUrl + "Account/Register";
            public const string Login = BaseUrl + "Account/Login";
        }

        public static class Products 
        {
            public const string GetAllProducts = BaseUrl + "Products"; 
        }
        #endregion
    }
}
