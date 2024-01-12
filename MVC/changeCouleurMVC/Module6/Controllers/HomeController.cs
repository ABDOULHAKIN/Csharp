using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Module6.Models;
using System.Diagnostics;

namespace Module6.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache) {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index() {
            string? nbAccesChaine = Request.Cookies["nbAcces"];
            int nbAcces = nbAccesChaine != null ? int.Parse(nbAccesChaine) + 1 : 1;
            TempData["nbAcces"] = nbAcces;
            Response.Cookies.Append("nbAcces", nbAcces.ToString());
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [HttpGet]
        public IActionResult Theme() {
            if (!_memoryCache.TryGetValue("couleurs", out IDictionary<string, string> couleurs)) {
                couleurs = new Dictionary<string, string> {
                    {"#000000", "Noir" },
                    {"#ff0000", "Rouge" },
                    {"#00ff00", "Vert" },
                    {"#0000ff", "Bleu" }
                };
                _memoryCache.Set("couleurs", couleurs);
            }
            return View(couleurs);
        }

        [HttpPost]
        public IActionResult Theme(string couleur) {
            HttpContext.Session.SetString("couleur", couleur);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}