using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security
{
    public class SuperAdminHandler : AuthorizationHandler<ManageUserRolesAndClaimsRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageUserRolesAndClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
