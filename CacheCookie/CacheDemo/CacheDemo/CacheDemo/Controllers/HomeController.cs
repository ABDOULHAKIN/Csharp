using CacheDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CacheDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }






        public IActionResult Index()
        {
            var valeurExistEnCache = !_memoryCache.TryGetValue("demoCache", out String valeurEnCache);
            if (valeurExistEnCache)
            {
                
                Thread.Sleep(10000); //simulation d'un traitement long
                valeurEnCache = "Valeur en cache";
                _memoryCache.Set("demoCache", valeurEnCache);
            }

            TempData["valeur"] = valeurEnCache;
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