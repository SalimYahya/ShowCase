using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.Operations
{
    public class ConfirmOrderAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Invoice>
    {
        private readonly ILogger<ConfirmOrderAuthorizationHandler> _logger;

        public ConfirmOrderAuthorizationHandler(ILogger<ConfirmOrderAuthorizationHandler> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, 
            Invoice resource)
        {
            _logger.LogInformation($"context.User.Identity.Name: {context.User.Identity.Name} -- Invoice.ApplicationUser.UserName: {context.User.Identity.Name}");
            _logger.LogInformation($"context.User.Claims: {context.User.Claims}");

            var isUserInAdminstrativeRole = context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor");
            var isOrderBelongsToUser = context.User.Identity.Name == resource.ApplicationUser.UserName;

            // Operation: Update ==> Confirm Order
            if (requirement.Name == "Update")
            {
                _logger.LogInformation($"requirement.Name: Read");
                if (isOrderBelongsToUser)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if (requirement.Name == "Read")
            {
                _logger.LogInformation($"requirement.Name: Read");
                if (isOrderBelongsToUser || isUserInAdminstrativeRole)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }

    }
}
