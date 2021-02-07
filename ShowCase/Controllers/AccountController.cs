using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShowCase.Models;
using ShowCase.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Registeration model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City
                };

                var registerationResult = await userManager.CreateAsync(user, model.Password);
                if (registerationResult.Succeeded)
                {
                    //await userManager.AddToRoleAsync(user, "Admin");
                    await userManager.AddToRoleAsync(user, "Customer");

                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "home");
                }

                // Catch Errors
                foreach (var error in registerationResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid) {
                var loginResult = await signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    false );

                if (loginResult.Succeeded) {

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) {

                        return Redirect(returnUrl);
                    }
                    else{
                        return RedirectToAction("index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Username/Password");
                
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if ( HttpContext.Session.GetString("CartCount") != null)
            {
                HttpContext.Session.Remove("CartCount");
            }

            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }
}
