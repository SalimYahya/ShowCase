using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShowCase.Security.Operations.UserInformation
{
    public class UserAddressInformationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Address>
    {
        private readonly ILogger<UserAddressInformationHandler> _logger;

        public UserAddressInformationHandler(ILogger<UserAddressInformationHandler> logger)
        {
            _logger = logger;
        }


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Address resource)
        {
            _logger.LogInformation($"context.User.Identity.Name: {context.User.Identity.Name}");
            _logger.LogInformation($"context.User.Claims: {context.User.Claims}");

            var isUserInAdminstrativeRole = context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor");

            // Operation: Create
            if (requirement.Name == "Create")
            {
                _logger.LogInformation($"requirement.Name: Create");

                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            // Operation: Update (Edit)
            if (requirement.Name == "Update")
            {
                _logger.LogInformation($"requirement.Name: Update");
                var isInformationBelongsToUser = context.User.Identity.Name == resource.ApplicationUser.UserName;

                if (isInformationBelongsToUser)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            // Operation: Delete
            if (requirement.Name == "Delete")
            {
                _logger.LogInformation($"requirement.Name: Delete");
                var isInformationBelongsToUser = context.User.Identity.Name == resource.ApplicationUser.UserName;

                if (isInformationBelongsToUser || context.User.IsInRole("SuperAdmin"))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
