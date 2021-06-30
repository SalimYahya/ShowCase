using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowCase.Models;
using ShowCase.Repository.Contracts;
using ShowCase.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AccountController(ILogger<AccountController> logger, 
            IUserRepository userRepository, 
            IRoleRepository roleRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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
                };

                var registerationResult = await _userRepository.AddUserAsync(user, model.Password);

                if (registerationResult.Succeeded)
                {

                    _logger.LogInformation($"Result: {registerationResult.Succeeded}");
                    
                    IEnumerable<string> roles = new string[] { "Customer","Seller" };
                    await _roleRepository.AddUserToRolesAsync(user, roles);
                    await _userRepository.UserSignInAsync(user, false);

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
                var loginResult = await _userRepository.UserPasswordSignInAsync(
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

            //await signInManager.SignOutAsync();
            await _userRepository.UserSignOutAsync();

            return RedirectToAction("index", "home");
        }

    }
}
