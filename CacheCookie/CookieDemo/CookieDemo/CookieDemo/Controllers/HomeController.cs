using CookieDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookieDemo.Controllers
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
            string? valeur = HttpContext.Session.GetString("demo");

            // string? cookieTest = Request.Cookies["test"];
            if (valeur == null)
            {
                TempData["test"] = "Pas de valeur en session";
            }
            else
            {
                TempData["test"] = valeur;
            }
            return View();
        }

        public IActionResult Privacy(string name)
        {
            //Response.Cookies.Append("test", "Hello World!");
            HttpContext.Session.SetString("demo", "valeur en session:" + name);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}