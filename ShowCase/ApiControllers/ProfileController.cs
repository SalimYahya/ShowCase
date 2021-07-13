using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Extensions;
using ShowCase.Models;
using ShowCase.Models.DTOs.Responses;
using ShowCase.Repository.Contracts;
using ShowCase.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IUserRepository _userRepository;
        private UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IAuthorizationService _authorizationService;

        public ProfileController(ILogger<ProfileController> logger,
            IUserRepository userRepository,
            UserManager<ApplicationUser> userManager,
            AppDbContext appDbContext,
            IAuthorizationService authorizationService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInformtion()
        {
            ApplicationUser user = await _userRepository.GetUserInformationAsync(HttpContext.GetUserId());
            if (user == null) { return NotFound(); }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, user, CRUD.Read);
            if (authorizationResult.Succeeded) { return Ok(user); }
            else if (User.Identity.IsAuthenticated) 
            {
                return BadRequest(new { Success = false, Errors = new List<string> { "forbidden" } });
            }
            else 
            {
                return BadRequest(new 
                {
                    Success = false,
                    Errors = new List<string>()
                        {
                            "You are not logged in"
                        }
                });
            }
        }

        [HttpGet("usrId")]
        public async Task<IActionResult> GetUserInformtion(string userId)
        {
            ApplicationUser user = await _userRepository.GetUserInformationAsync(HttpContext.GetUserId());
            if (user == null) { return NotFound(); }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, user, CRUD.Read);
            if (authorizationResult.Succeeded) { return Ok(user); }
            else if (User.Identity.IsAuthenticated)
            {
                return BadRequest(new { Success = false, Errors = new List<string> { "forbidden" } });
            }
            else
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string>()
                        {
                            "You are not logged in"
                        }
                });
            }
        }
    }



    //_logger.LogInformation($"UserId: {userId} --- {HttpContext.User.Claims.Single(x => x.Type == "Id")}");
}
