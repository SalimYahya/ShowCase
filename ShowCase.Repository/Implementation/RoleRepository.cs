using Microsoft.AspNetCore.Identity;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Implementation
{
    public class RoleRepository : RepositoryBase<IdentityRole, string>, IRoleRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleRepository(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> AddUserToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return await _userManager.AddToRolesAsync(user, roles);
        }

        public async Task<IdentityResult> RemoveUserFromRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveUserFromRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }
    }
}
