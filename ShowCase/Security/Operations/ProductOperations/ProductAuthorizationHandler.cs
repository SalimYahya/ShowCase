using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.Operations.ProductOperations
{
    public class ProductAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Product>
    {
        private readonly ILogger<ProductAuthorizationHandler> _logger;

        public ProductAuthorizationHandler(ILogger<ProductAuthorizationHandler> logger)
        {
            _logger = logger;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                        OperationAuthorizationRequirement requirement,
                                                        Product resource)
        {

            _logger.LogInformation($"context.User.Identity.Name: {context.User.Identity.Name}");
            _logger.LogInformation($"context.User.Claims: {context.User.Claims}");

            // Operation.Create
            var isUserCanCreate = context.User.HasClaim(claim => claim.Type == "Create Product" && claim.Value == "true");
            if (requirement.Name == "Create")
            {
                _logger.LogInformation($"requirement.Name: Create");

                if (isUserCanCreate)
                {
                    _logger.LogInformation($"isUserCanCreatee: {isUserCanCreate}");
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }



            // Operation.Update
            _logger.LogInformation($"resource.ApplicationUser.UserName: {resource.ApplicationUser.UserName}");

            var isProductBelongsToUser = (context.User.IsInRole("Seller")) && (context.User.Identity.Name == resource.ApplicationUser.UserName);
            var isUserCanUpdateProduct = context.User.HasClaim(claim => claim.Type == "Edit Product" && claim.Value == "true");
            _logger.LogInformation($"isProductBelongsToUser: {isProductBelongsToUser}");
            _logger.LogInformation($"isUserCanUpdateProduct: {isUserCanUpdateProduct}");
            if (requirement.Name == "Update")
            {
                _logger.LogInformation($"requirement.Name: Update");

                if (isProductBelongsToUser && isUserCanUpdateProduct)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }



            // Operation.Delete
            var isUserSuperAdminOrSupervisor = context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Supervisor");
            var isUserCanDeleteProduct =  context.User.HasClaim(claim => claim.Type == "Delete Product" && claim.Value == "true");
            if (requirement.Name == "Delete")
            {
                _logger.LogInformation($"requirement.Name: Delete");
                _logger.LogInformation($"isProductBelongsToUser: {isProductBelongsToUser}");
                _logger.LogInformation($"isUserCanDeleteProduct: {isUserCanDeleteProduct}");

                if ( isProductBelongsToUser && isUserCanDeleteProduct)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
                else if (isUserSuperAdminOrSupervisor)
                {
                    _logger.LogInformation($"isUserSuperAdminOrSupervisor: {isUserSuperAdminOrSupervisor}");
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
