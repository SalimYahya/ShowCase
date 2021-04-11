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
    public class OrderAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, List<Product>>
    {
        private readonly ILogger<OrderAuthorizationHandler> _logger;

        public OrderAuthorizationHandler(ILogger<OrderAuthorizationHandler> logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, List<Product> resource)
        {
            _logger.LogInformation($"context.User.Identity.Name: {context.User.Identity.Name}");
            _logger.LogInformation($"context.User.IsInRole(Customer): {context.User.IsInRole("Customer")}");

            var isUserNotTheOwner = true;
            var isUserWithCustomerRole = context.User.IsInRole("Customer");
            //var isUserCanCreate = context.User.HasClaim(claim => claim.Type == "Create Product" && claim.Value == "true");
            if (requirement.Name == "Create" && isUserWithCustomerRole)
            {
                foreach (var item in resource)
                {
                    if (context.User.Identity.Name == item.ApplicationUser.UserName) { isUserNotTheOwner = false;  }
                }

                if (isUserNotTheOwner) 
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            
            return Task.CompletedTask;
        }
    }
}
