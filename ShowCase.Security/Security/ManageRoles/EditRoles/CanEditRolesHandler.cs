using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Security.ManageRoles.EditRoles
{
    public class CanEditRolesHandler : AuthorizationHandler<EditRolesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EditRolesRequirement requirement)
        {
            var canEdit = ((context.User.IsInRole("Admin") || context.User.IsInRole("Supervisor")) &&
                               context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true")) ||
                               context.User.IsInRole("Super Admin");

            if (canEdit)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
