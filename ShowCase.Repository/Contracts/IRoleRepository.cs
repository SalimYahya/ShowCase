using Microsoft.AspNetCore.Identity;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Contracts
{
    public interface IRoleRepository : IRepositoryBase<IdentityRole, string>
    {
        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> AddUserToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
        Task<IdentityResult> RemoveUserFromRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveUserFromRolesAsync(ApplicationUser user, IEnumerable<string> roles);

    }
}
