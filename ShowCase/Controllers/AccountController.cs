using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ILogger<AccountController> logger, 
            IUserRepository userRepository, 
            IRoleRepository roleRepository,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userManager = userManager;
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
                    
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var link = Url.Action("ConfirmEmail", 
                                          "Account",
                                          new { userId = user.Id, token = token},
                                          Request.Scheme);

                    //_logger.LogInformation($"Link: {link}");
                    //_logger.LogInformation($"Result: {registerationResult.Succeeded}");
                    
                    IEnumerable<string> roles = new string[] { "Customer","Seller" };
                    await _roleRepository.AddUserToRolesAsync(user, roles);
                   
                    ViewData["link"] = link;
                    return View();

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
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogInformation($"userId - {userId}, is Invalid");
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
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
