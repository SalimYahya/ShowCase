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
    public class ConfirmOrderHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Invoice>
    {
        private readonly ILogger<ConfirmOrderHandler> _logger;

        public ConfirmOrderHandler(ILogger<ConfirmOrderHandler> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Invoice resource)
        {
            _logger.LogInformation($"context.User.Identity.Name: {context.User.Identity.Name} -- Invoice.ApplicationUser.UserName: {context.User.Identity.Name}");

            var isOrderBelongsToUser = context.User.Identity.Name == context.User.Identity.Name;

            // Operation: Update ==> Confirm Order
            if (requirement.Name == "Update")
            {
                if (isOrderBelongsToUser)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
