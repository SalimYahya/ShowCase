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
    [Authorize(Roles = "Admin, User")]
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminstrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<IdentityRole> roles = roleManager.Roles;
            return View(roles);
        }

        public IActionResult Users()
        {
            IEnumerable<ApplicationUser> users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    return RedirectToAction("index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            var model = new EditViewModel
            {
                Id= role.Id,
                RoleName = role.Name
            };

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
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.RoleName;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
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
            EditUserViewModel model = new EditUserViewModel
            {
                User = user
            };

            foreach (var role in roleManager.Roles)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Roles.Add(role.Name);
                }
            }

            var claims = await userManager.GetClaimsAsync(user);

            foreach (var claim in claims)
            {
                model.Claims.Add(claim.Type);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string id)
        {
            ViewBag.userId = id;

            ApplicationUser user = await userManager.FindByIdAsync(id);

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
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string id)
        {

            ApplicationUser user = await userManager.FindByIdAsync(id);

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

            return RedirectToAction("EditUser", new { Id = id});
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string id)
        {
            ViewBag.userId = id;
            ApplicationUser user = await userManager.FindByIdAsync(id);

            var existingUserClaims = await userManager.GetClaimsAsync(user);

            UserClaimsViewModel model = new UserClaimsViewModel
            {
                UserId = id
            };

            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                model.Claims.Add(userClaim);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model, string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            var claims = await userManager.GetClaimsAsync(user);
            var result = await userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            result = await userManager.AddClaimsAsync(user, 
                model.Claims.Where(x => x.IsSelected)
                            .Select(c => new Claim(c.ClaimType, c.ClaimType)));
            
            if (!result.Succeeded)
            {
                ModelState.AddModelError("","Cannot Add Selected Claims to User");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = id});
        }
    }
}
