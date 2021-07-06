using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.Operations.UserInformation
{
    public class UserListHandler : AuthorizationHandler<OperationAuthorizationRequirement, IEnumerable<ApplicationUser>>
    {
        private readonly ILogger<UserListHandler> _logger;

        public UserListHandler(ILogger<UserListHandler> logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, IEnumerable<ApplicationUser> resource)
        {
            _logger.LogInformation($"context.User.Identity.Name: {context.User.Identity.Name}");
            _logger.LogInformation($"context.User.Claims: {context.User.Claims}");

            var isUserInAdminstrativeRole = context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor");

            // Operation: Read
            if (requirement.Name == "Read")
            {
                _logger.LogInformation($"requirement.Name: Read");

                if (isUserInAdminstrativeRole)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;

        }
    }
}
