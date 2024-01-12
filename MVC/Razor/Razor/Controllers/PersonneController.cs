using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class PersonneController : Controller
    {
        // GET: PersonneController
        public ActionResult Index()
        {
            var personnes = new List<Personne>()
            {
                new Personne() { Nom = "Mohamed Omar", Age=30, Id=1},
                new Personne() { Nom = "Jean Ali", Age = 29, Id = 2 },
                new Personne() { Nom = "Waberi Ahmed", Age = 45, Id = 3 },
                new Personne() { Nom = "Junior Junior", Age = 69, Id = 4 },
                new Personne() { Nom = "Idman Abdoulhakin", Age = 1, Id = 5 }
            };
            return View(personnes);
        }

        // GET: PersonneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
