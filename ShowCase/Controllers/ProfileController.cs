using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public ProfileController(UserManager<ApplicationUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> UserInformation()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            EditUserViewModel model = new EditUserViewModel
            {
                User = user,
                Claims = userClaims.Select(c => c.Type + " : " + c.Value).ToList(),
                Roles = userRoles.ToList()
            };


            return View(model);
        }

        public async Task<IActionResult> UserOrders()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            var invoiceList = _appDbContext.Invoices.Include(u => u.ApplicationUser)
                                                    .Where(i=> i.ApplicationUserId == userId);

            return View(invoiceList);
        }
    }
}
