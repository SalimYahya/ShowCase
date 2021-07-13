using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.ManageRoles.ReadRoles
{
    public class CanReadRolesHandler : AuthorizationHandler<ReadRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadRoleRequirement requirement)
        {
            var canRead = ((context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor")) &&
                                           context.User.HasClaim(claim => claim.Type == "Read Role" && claim.Value == "true")) ||
                                           context.User.IsInRole("Super Admin");

            if (canRead)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
