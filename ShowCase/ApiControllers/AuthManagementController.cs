using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShowCase.Configuration;
using ShowCase.Models;
using ShowCase.Models.DTOs.Requests;
using ShowCase.Models.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthManagementController : ControllerBase
    {
        private readonly ILogger<AuthManagementController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagementController(
            ILogger<AuthManagementController> logger,
            UserManager<ApplicationUser> userManager,
            IOptionsMonitor<JwtConfig> optionMonitor)
        {
            _logger = logger;
            _userManager = userManager;
            _jwtConfig = optionMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    return BadRequest(new UserRigistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Email already in use !!!"
                        }
                    });
                }

                var newUser = new ApplicationUser {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.Email,
                    Email = user.Email
                };

                var registrationResult = await _userManager.CreateAsync(newUser, user.Password);
                if (registrationResult.Succeeded)
                {
                    /* Code here to asign the new user wih roles
                     * IEnumerable<string> roles = new string[] { "Customer","Seller" };
                     * await userManager.AddToRolesAsync(user, roles);
                     */

                    var jwtToken = await GenerateJwtTokenAsync(newUser);
                    return Ok(new UserRigistrationResponse() {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new UserRigistrationResponse()
                    {
                        Success = false,
                        Errors = registrationResult.Errors.Select(x => x.Description).ToList()
                    });
                }
            }

            return BadRequest(new UserRigistrationResponse() {
                Success = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    return BadRequest(new UserRigistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid Login Request"
                        }
                    });
                }

                var isValidUser = await _userManager.CheckPasswordAsync(existingUser, user.Password);
                if (!isValidUser)
                {
                    return BadRequest(new UserRigistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid User"
                        }
                    });
                }

                var jwtToken = await GenerateJwtTokenAsync(existingUser);

                return Ok(new UserRigistrationResponse() { 
                    Success = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new UserRigistrationResponse()
            {
                Success = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }

        private async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim("Name",user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var claimss = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
