using Microsoft.AspNetCore.Identity;
using ShowCase.Models;
using ShowCase.Models.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.Admin
{
    public class AdminstrationViewModel
    {
        public AdminstrationViewModel()
        {
            userRolesAndClaims = new List<UserRolesAndClaims>();
            roles = new List<IdentityRole>();
        }

        public List<UserRolesAndClaims> userRolesAndClaims { get; set; }
        public List<IdentityRole> roles { get; set; }
    }
}
