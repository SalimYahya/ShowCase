using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShowCase.Models.UserClaims
{
    public static class CustomerClaims
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Buy Product","Buy Product"),
        };
    }
}
