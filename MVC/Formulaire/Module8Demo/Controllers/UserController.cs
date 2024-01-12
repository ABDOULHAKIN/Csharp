using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Module8Demo.Strategies;

namespace Module8Demo.Controllers
{

  // [Authorize(Roles = "admin")]
    public class UserController : Controller
    {

        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager, IAuthorizationService authorizationService)
        {
            this.userManager = userManager;
            this.authorizationService = authorizationService;
        }

      
        public async Task<IActionResult> Index()
        {

            var authorization = await authorizationService
                .AuthorizeAsync(User, null, new DomainRequirement("campus-eni.fr"));
            if (!authorization.Succeeded)
                return Forbid();

            List<IdentityUser> users = userManager.Users.ToList();
            return View(users);
        }



    }
}
