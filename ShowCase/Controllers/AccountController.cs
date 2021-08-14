using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Providers;
using ShowCase.Repository.Contracts;
using ShowCase.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMailHelper _mailHelper;
        private readonly ITemplateHelper _helper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ILogger<AccountController> logger,
            IMailHelper mailHelper,
            ITemplateHelper helper,
            IUserRepository userRepository, 
            IRoleRepository roleRepository,
            AppDbContext appDbContext,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _mailHelper = mailHelper;
            _helper = helper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _appDbContext = appDbContext;
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
                    
                    IEnumerable<string> roles = new string[] { "Customer","Seller" };
                    await _roleRepository.AddUserToRolesAsync(user, roles);
                    BackgroundJob.Enqueue(() => AccountActivationNotificationAsync(model.Email, link));

                    ViewData["Notification"] = "Please Check your email to confirm activation";
                    
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

        [AutomaticRetry(Attempts = 20)]
        public async Task AccountActivationNotificationAsync(string email, string link)
        {

            var notification = new EmailBase
            {
                To = email,
                From = "admin@showcase.com",
                Subject = "Account Activation",
                Text = link
            };

            var response = await _helper.GetTemplateHtmlAsStringAsync(
                "Emails/EmailAccountActivation",
                notification
            );

           await _mailHelper.SendEmailAsync(email, "test", response);
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

                // Login Attempt Error
                var usernameExist = _appDbContext.ApplicationUsers.Count(u => u.Email == model.Email);
                if (usernameExist > 0)
                {
                    BackgroundJob.Enqueue(( ) => LoginNotificationAsync(model.Email));
                }
                
                ModelState.AddModelError(string.Empty, "Invalid Username/Password");
                
            }

            return View(model);
        }

        [AutomaticRetry(Attempts = 20)]
        public async Task LoginNotificationAsync(string email) 
        {

            var notification = new EmailBase { 
                To = email,
                From = "admin@showcase.com",
                Subject = "Failed Login Attempt",
                Text = "Our system encounter Failed Login attempt by your username."
            };

            var response = await _helper.GetTemplateHtmlAsStringAsync(
                "Emails/LoginNotificaiton",
                notification
            );

            await _mailHelper.SendEmailAsync(email, "test", response);
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



//SmtpClient smtpClient = new SmtpClient("mail.ShowCase.com", 25);
//smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
//smtpClient.PickupDirectoryLocation = @"C:\Email";

//MailMessage message = new MailMessage();
//message.From = new MailAddress("admin@Showcase", "ShowCase.com");
//message.To.Add(new MailAddress(email));
//message.Body = "Login Notification";



//smtpClient.Send(message);
