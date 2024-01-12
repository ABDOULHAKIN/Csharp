using BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPPizza.Models;

namespace TPPizza.Controllers {
    public class PizzaController : Controller {

        private static List<Pizza> pizzas = new List<Pizza> {
            new Pizza{Id = 1, Nom="Calzone", Pate=Pizza.PatesDisponibles[1],
                Ingredients=Pizza.IngredientsDisponibles.Where(i => i.Id%3 == 0).ToList() },
            new Pizza{Id = 2, Nom="2 fromages", Pate=Pizza.PatesDisponibles[2],
                Ingredients = new List<Ingredient> { Pizza.IngredientsDisponibles[0], Pizza.IngredientsDisponibles[4]}
                }
        };

        // GET: PizzaController
        public ActionResult Index() {
            return View(pizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id) {
            Pizza? pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if(pizza == null) return NotFound();
            return View(pizza);
        }

        // GET: PizzaController/Create
        public ActionResult Create() {
            return View(new PizzaVM());
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaVM pizzaVM) {
            try {
                if (Valider(pizzaVM)) {
                    Pizza pizza = new Pizza {
                        Id = pizzas.OrderByDescending(p => p.Id).FirstOrDefault()?.Id + 1 ?? 1,
                        Nom = pizzaVM.Nom,
                        Pate = Pizza.PatesDisponibles.First(p => p.Id == pizzaVM.IdPate),
                        Ingredients = Pizza.IngredientsDisponibles.Where(i => pizzaVM.IdsIngredients.Contains(i.Id)).ToList()
                    };
                    pizzas.Add(pizza);
                    return RedirectToAction(nameof(Index));
                } else return View(pizzaVM);
            } catch {
                return View(pizzaVM);
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id) {
            Pizza? pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null) return NotFound();
            PizzaVM pizzaVM = new PizzaVM {
                Id = pizza.Id,
                Nom = pizza.Nom,
                IdPate = pizza.Pate.Id,
                IdsIngredients = pizza.Ingredients.Select(i => i.Id).ToList()
            };
            return View(pizzaVM);
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzaVM pizzaVM) {
            try {
                if(id != pizzaVM.Id) return BadRequest();
                Pizza? pizza = pizzas.FirstOrDefault(p => p.Id == id);
                if(pizza == null) return NotFound();
                if (Valider(pizzaVM)) {
                    pizza.Nom = pizzaVM.Nom;
                    pizza.Pate = Pizza.PatesDisponibles.First(p => p.Id == pizzaVM.IdPate);
                    pizza.Ingredients = Pizza.IngredientsDisponibles
                        .Where(i => pizzaVM.IdsIngredients.Contains(i.Id)).ToList();
                    return RedirectToAction(nameof(Index));
                } else return View(pizzaVM);
            } catch {
                return View(pizzaVM);
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id) {
            Pizza? pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null) return NotFound();
            return View(pizza);
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                Pizza? pizza = pizzas.FirstOrDefault(p => p.Id == id);
                if (pizza == null) return NotFound();
                pizzas.Remove(pizza);
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        private bool Valider(PizzaVM pizzaVM) {
            if (!ModelState.IsValid) return false;

            int nbIng = pizzaVM.IdsIngredients.Count();
            if (nbIng < 2 || nbIng > 5) {
                ModelState.AddModelError("IdsIngredients", "Une pizza doit avoir entre 2 et 5 ingrédients");
                return false;
            }

            string nomPizza = pizzaVM.Nom.ToLower();
            if (pizzas.Any(p => p.Nom.ToLower() == nomPizza && p.Id != pizzaVM.Id)) {
                ModelState.AddModelError("Nom", "Une autre pizza porte déjà ce nom");
                return false;
            }

            if (pizzas.Where(p => p.Ingredients.Count() == nbIng && p.Id != pizzaVM.Id)
                .Any(p => p.Ingredients.All(i => pizzaVM.IdsIngredients.Contains(i.Id)))) {
                ModelState.AddModelError("IdsIngredients",
                    "Deux pizzas ne peuvent avoir la même liste d'ingrédients");
                return false;
            }

            return true;
        }
    }
}
