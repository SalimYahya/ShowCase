using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShowCase.Models;
using ShowCase.Repository.Contracts;
using ShowCaseAPI.Configuration;
using ShowCaseAPI.DTO;
using ShowCaseAPI.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthManagementController> _logger;
        private readonly JwtConfig _jwtConfig;

        public AuthManagementController(
            ILogger<AuthManagementController> logger,
            IUserRepository userRepository,
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _logger = logger;
            _userRepository = userRepository;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Registration user) 
        {
            OperationResponse operationResponse = new OperationResponse();
            var isSucceeded = false;

            if (ModelState.IsValid) 
            {
                var existUser = await _userRepository.GetUserByEmail(user.Email);
                if (existUser != null) 
                {
                    operationResponse.Success = isSucceeded;
                    operationResponse.Errors = new List<string>() { "Email already in use !!!" };

                    return BadRequest(operationResponse);
                }

                var newUser = new ApplicationUser 
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.Email
                };

                var registrationResult = await _userRepository.AddUserAsync(newUser, user.Password);
                if (registrationResult.Succeeded)
                {
                    IEnumerable<string> roles = new string[] { "Customer", "Seller" };
                    await _userRepository.AddUserToRoles(newUser, roles);
                    var jwtToken = await GenerateTokenAsync(newUser);
                    isSucceeded = true;

                    operationResponse.Success = isSucceeded;
                    operationResponse.Token = jwtToken;

                    return Ok(operationResponse);
                }

                operationResponse.Errors = registrationResult.Errors.Select(x => x.Description).ToList();

                return BadRequest(operationResponse);
            }

            operationResponse.Errors = new List<string>() { "Invalid Payloads !!!" };
            return BadRequest(operationResponse);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login user) 
        {
            OperationResponse operationResponse = new OperationResponse();
            var isSucceeded = false;

            if (ModelState.IsValid) 
            {
                var existUser = await _userRepository.GetUserByEmail(user.Email);
                if (existUser == null) 
                {
                    operationResponse.Success = isSucceeded;
                    operationResponse.Errors = new List<string>() { "Email/Username is Invalid" };
                    return BadRequest(operationResponse);        
                }

                var isValidUser = await _userRepository.CheckUserPasswordAsync(existUser, user.Password);
                if (!isValidUser)
                {
                    operationResponse.Success = isSucceeded;
                    operationResponse.Errors = new List<string>() { "Password is Invalid" };
                    return BadRequest(operationResponse);
                }

                var jwtToken = await GenerateTokenAsync(existUser);

                isSucceeded = true;
                operationResponse.Success = isSucceeded;
                operationResponse.Token = jwtToken;

                return Ok(operationResponse);
            }

            operationResponse.Success = isSucceeded;
            operationResponse.Errors = new List<string>() { "Invalid Payloads !!!" };
            return BadRequest(operationResponse);
        }

        #region GenrateToken
        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            List<Claim> tokenClaims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userClaims = await _userRepository.GetUserClaimsAsync(user);
            tokenClaims.AddRange(userClaims);

            var userRoles = await _userRepository.GetUserRolesAsync(user);
            foreach (var role in userRoles) { tokenClaims.Add(new Claim(ClaimTypes.Role, role)); }

            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(tokenClaims),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        #endregion
    }
}
