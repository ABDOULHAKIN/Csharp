using Microsoft.AspNetCore.Mvc;

namespace EscapeGame.Controllers {
    public class MachinController : Controller {
        public IActionResult Truc() {
            return View();
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Bidule(int id) {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult Jo() { return View(); }

        [Route("/A/{v1}/B/{v2}/C")]
        public IActionResult Fin(int v1, int v2) {
            ViewBag.Valeur = v1 * v2;
            return View();
        }
    }
}
