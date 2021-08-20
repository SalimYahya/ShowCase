using CrossPlatformApp.DTO.Account;
using CrossPlatformApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformApp.Services.Contacts
{
    public interface IUserService
    {
        Task<JwtToken> Login(Login login);
    }
}
