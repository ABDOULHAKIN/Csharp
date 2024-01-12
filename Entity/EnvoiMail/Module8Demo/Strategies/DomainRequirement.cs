using Microsoft.AspNetCore.Authorization;

namespace Module8Demo.Strategies
{
    public class DomainRequirement : IAuthorizationRequirement
    {

        public string Domaine { get; }

        public DomainRequirement(string domaine)
        {
            Domaine = domaine;
        }
    }
}
