using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformApp.Models
{
    public class JwtToken
    {
        public int Id { get; set; } 
        public string Token { get; set; }
        public string RefreshToken { get; set; } 
        public bool Success { get; set; } = false;
        public List<string> Errors { get; set; }
        public DateTime ExpireDate { get; set; }

        public JwtToken() { }

        public override string ToString()
        {
            return String.Format("ID: {0}, Token: {1}" +
                "Token: {1}\n" +
                "RefreshToken: {2}\n" +
                "Success: {3}\n" +
                "Errors: {4}\n" +
                "Expire_Date: {5}\n", 
                this.Id, this.Token, this.RefreshToken, this.Success, this.Errors.ToString(), this.ExpireDate );
        }
    }
}
