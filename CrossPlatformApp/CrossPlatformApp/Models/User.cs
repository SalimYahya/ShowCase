using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
