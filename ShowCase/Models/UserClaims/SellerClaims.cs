using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShowCase.Models.UserClaims
{
    public static class SellerClaims
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Product", "Create Product"),
            new Claim("Edit Product", "Edit Product"),
            new Claim("Delete Product", "Delete Product")
        };
    }
}
