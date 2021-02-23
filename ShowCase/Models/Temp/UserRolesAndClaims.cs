using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models.Temp
{
    public class UserRolesAndClaims
    {
        public UserRolesAndClaims()
        {
            Roles = new List<string>();
            Claims = new List<string>();
        }

        public ApplicationUser applicationUser { get; set; }

        public List<string> Roles { get; set; }
        public List<string> Claims { get; set; }
    }
}
