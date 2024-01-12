using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Module8Demo.Strategies
{
    public class DomainHandler : AuthorizationHandler<DomainRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DomainRequirement requirement)
        {
            var domainClaim = context.User.FindFirst(c => c.Type == ClaimTypes.Email);
            if (domainClaim != null)
            {
                string domaine = domainClaim.Value.Split('@')[1]; //user@gmail.com => gmail.com
                if (domaine == requirement.Domaine)
                    context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
