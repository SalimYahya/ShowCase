using Microsoft.AspNetCore.Authorization;
using ShowCase.Security.ManageRoles.DeleteRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.ManageRoles
{
    public class CanDeleteRolesHandler : AuthorizationHandler<DeleteRolesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DeleteRolesRequirement requirement)
        {
            
            var canDelete = ((context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor")) &&
                               context.User.HasClaim(claim => claim.Type == "Delete Role" && claim.Value == "true")) ||
                               context.User.IsInRole("Super Admin");


            if (canDelete)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
