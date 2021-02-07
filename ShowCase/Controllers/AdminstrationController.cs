using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShowCase.Models;
using ShowCase.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    [Authorize(Roles = "Super Admin, Admin, Supervisor")]
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminstrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult RolesList()
        {
            IEnumerable<IdentityRole> roles = roleManager.Roles;
            return View(roles);
        }

        public IActionResult UsersList()
        {
            IEnumerable<ApplicationUser> users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        [Authorize(Policy = "CreateRolePolicy")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CreateRolePolicy")]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid) 
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Adminstration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            var model = new EditRoleViewModel { Id = role.Id, RoleName = role.Name };

            foreach (var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.RoleName;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("EditRole", new { Id = role.Id });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "DeleteRolePolicy")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);

            return RedirectToAction("RolesList", "Adminstration");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var roles = await userManager.GetRolesAsync(user);
            if (roles.Count > 0)
            {
                await userManager.RemoveFromRolesAsync(user, roles);
            }

            await userManager.DeleteAsync(user);

            return RedirectToAction("UsersList", "Adminstration");
        }


        [HttpGet]
        public async Task<IActionResult> EditUsersInRoles(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            ViewBag.roleId = id;
            ViewBag.roleName = role.Name;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRoles(List<UserRoleViewModel> model, string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            for (int i = 0; i < model.Count; i++ )
            {
                ApplicationUser user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("Edit", new { Id = id});
                }
            }

            return RedirectToAction("Edit", new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            EditUserViewModel model = new EditUserViewModel
            {
                User = user,
                Claims = userClaims.Select(c => c.Type +" : "+ c.Value).ToList(),
                Roles = userRoles.ToList()
            };

            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByIdAsync(model.User.Id);

                user.FirstName = model.User.FirstName;
                user.LastName = model.User.LastName;

                await userManager.UpdateAsync(user);

                return RedirectToAction("UsersList", "Adminstration");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "EditUserRolesAndPolicy")]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            ApplicationUser user = await userManager.FindByIdAsync(userId);

            var model = new List<UserRolesViewModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel 
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if ( await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }
        
        [HttpPost]
        [Authorize(Policy = "EditUserRolesAndPolicy")]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {

            ApplicationUser user = await userManager.FindByIdAsync(userId);

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user, 
                model.Where(x => x.IsSelected)
                     .Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add  selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId});
        }

        [HttpGet]
        [Authorize(Policy = "EditUserRolesAndPolicy")]
        public async Task<IActionResult> ManageUserClaims(string userId)
        {
            ViewBag.userId = userId;
            ApplicationUser user = await userManager.FindByIdAsync(userId);

            var existingUserClaims = await userManager.GetClaimsAsync(user);

            UserClaimsViewModel model = new UserClaimsViewModel
            {
                UserId = userId
            };

            foreach (Claim claim in AdminClaims.AllClaims)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                if (existingUserClaims.Any(c => c.Type == claim.Type && c.Value == "true"))
                {
                    userClaim.IsSelected = true;
                }

                model.Claims.Add(userClaim);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "EditUserRolesAndPolicy")]
        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model, string userId)
        {
            ApplicationUser user = await userManager.FindByIdAsync(userId);

            var claims = await userManager.GetClaimsAsync(user);
            var result = await userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            result = await userManager.AddClaimsAsync(user, 
                model.Claims.Select(c => new Claim(c.ClaimType, c.IsSelected ? "true":"false")));
            
            if (!result.Succeeded)
            {
                ModelState.AddModelError("","Cannot Add Selected Claims to User");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
