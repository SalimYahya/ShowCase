﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using ShowCase.Models;
using ShowCase.ViewModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.Operations
{
    public class UserPersonalInformationHandler :
                AuthorizationHandler<OperationAuthorizationRequirement, ApplicationUser>
    {
        private readonly ILogger<UserPersonalInformationHandler> _logger;

        public UserPersonalInformationHandler(ILogger<UserPersonalInformationHandler> logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, ApplicationUser resource)
        {
            _logger.LogInformation($"context.User.Identity.Name: {context.User.Identity.Name}");
            _logger.LogInformation($"context.User.Claims: {context.User.Claims}");

            var isUserInAdminstrativeRole = context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor");

            // Operation: Read
            if (requirement.Name == "Read")
            {
                _logger.LogInformation($"requirement.Name: Read");

                var isInformationBelongsToUser = context.User.Identity.Name == resource.UserName;
                if (isInformationBelongsToUser || isUserInAdminstrativeRole)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }                
            }

            // Operation: Update (Edit)
            if (requirement.Name == "Update")
            {
                _logger.LogInformation($"requirement.Name: Update");

                var isInformationBelongsToUser = context.User.Identity.Name == resource.UserName;
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

                var isInformationBelongsToUser = context.User.Identity.Name == resource.UserName;
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