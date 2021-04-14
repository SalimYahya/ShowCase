using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
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
        private UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IAuthorizationService _authorizationService;

        public ProfileController(ILogger<ProfileController> logger,
            UserManager<ApplicationUser> userManager,
            AppDbContext appDbContext,
            IAuthorizationService authorizationService)
        {
            _logger = logger;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _authorizationService = authorizationService;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserInformtion(string userName)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(userName);

            if (user == null) { return NotFound(); }

            return Ok(user);
        }
    }
}
