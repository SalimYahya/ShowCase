using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowCase.Repository.Contracts;
using ShowCase.Security;
using ShowCaseAPI.Extensions;
using ShowCaseAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IAuthorizationService _authorizartionService;

        public ProfileController(ILogger<ProfileController> logger,
            IUserRepository userRepository,
            IAuthorizationService authorizartionService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _authorizartionService = authorizartionService;
        }

        // GET api/<ProfileController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            OperationResponse operationResponse = new OperationResponse();
            var isSucceeded = false;
            
            var existUser = await _userRepository.GetUserInformationAsync(HttpContext.GetUserId());
            if (existUser == null)
            {   
                operationResponse.Success = isSucceeded;
                operationResponse.Errors = new List<string>() { "User Not Exists" };
                return BadRequest(operationResponse);
            }

            var authorizationResult = await _authorizartionService.AuthorizeAsync(User, existUser, CRUD.Read);
            if (authorizationResult.Succeeded) { return Ok(existUser); }
            else if (User.Identity.IsAuthenticated)
            {
                return BadRequest(new { Success = false, Errors = new List<string> { "forbidden" } });
            }
            else 
            { 
                return BadRequest(
                    new { Success = false, 
                        Errors = new List<string>() { "You are not logged in"}});
            }
        }

        // POST api/<ProfileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    /*
     *  OperationResponse operationResponse = new OperationResponse();
        var isSucceeded = false;
            

        operationResponse.Success = isSucceeded;
        operationResponse.Errors = new List<string>() { "Invalid Payloads !!!" };
        return BadRequest(operationResponse);
     */
}
