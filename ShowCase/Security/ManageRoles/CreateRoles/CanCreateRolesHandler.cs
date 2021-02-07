using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.ManageRoles.CreateRoles
{
    public class CanCreateRolesHandler : AuthorizationHandler<CreateRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreateRoleRequirement requirement)
        {
            var canCreate = ((context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor")) &&
                               context.User.HasClaim(claim => claim.Type == "Create Role" && claim.Value == "true")) ||
                               context.User.IsInRole("Super Admin");

            if (canCreate)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
