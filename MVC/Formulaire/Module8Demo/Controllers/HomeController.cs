using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module8Demo.Models;
using System.Diagnostics;

namespace Module8Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmaiService emaiService;

        public HomeController(ILogger<HomeController> logger, IEmaiService emaiService)
        {
            _logger = logger;
            this.emaiService = emaiService;
        }


        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
         
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}