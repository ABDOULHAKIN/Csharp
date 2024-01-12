using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using Razor.ViewModels;
using System.Diagnostics;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {   /*
            TempData["Message"] = "Message passé par TempData"; 
            Pour les redirections en meme espace persistance
            return RedirectToAction("Index");*/

            var vm = new MessageVM() { Message = "Je m'appelle Mohamed Omar"};
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
