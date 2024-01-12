#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BO;
using TPDojo.Data;
using TPDojo.Models;
using TPDojo.Pagination;

namespace TPDojo.Controllers
{
    public class SamouraisController : Controller
    {
        private readonly TPDojoContext _context;

        public SamouraisController(TPDojoContext context)
        {
            _context = context;
        }

        // GET: Samourais
        public async Task<IActionResult> Index(string tri, string recherche, string filtre, int? page)
        {
            ViewBag.OrdreTriActuel = tri;
            ViewBag.OrdreTri = string.IsNullOrEmpty(tri) ? "nomDesc" : "";
            ViewBag.OrdreTriForce = tri == "force" ? "forceDesc" : "force";
            if(recherche == null)
                recherche = filtre;
            else
                page = 1;
            ViewBag.Recherche = recherche;
            var samourais = _context.Samourais.Select(s => s);
            if(!string.IsNullOrEmpty(recherche)) {
                samourais = samourais.Where(s => s.Nom.StartsWith(recherche));
            }
            switch (tri) {
                case "nomDesc":
                    samourais = samourais.OrderByDescending(s => s.Nom);
                    break;
                case "force":
                    samourais = samourais.OrderBy(s => s.Force);
                    break;
                case "forceDesc":
                    samourais = samourais.OrderByDescending(s => s.Force);
                    break;
                default:
                    samourais = samourais.OrderBy(s => s.Nom);
                    break;
            }
            int nbParPage = 7;
            int numPage = (page ?? 1);
            return View(await PaginatedList<Samourai>.CreerAsync(samourais, numPage, nbParPage));
            //return View(samourais.ToPagedList(numPage, nbParPage));
        }

        // GET: Samourais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samourai = await _context.Samourais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samourai == null)
            {
                return NotFound();
            }

            return View(samourai);
        }

        // GET: Samourais/Create
        public IActionResult Create()
        {
            var samouraiVM = new SamouraiVM {
                Samourai = new Samourai { Nom = "" },
                ChoixArme = SelectListArmes()
            };
            return View(samouraiVM);
        }

        // POST: Samourais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SamouraiVM samouraiVM)
        {
            if (ModelState.IsValid)
            {
                /*if(samouraiVM.IdArme != null)
                    samouraiVM.Samourai.Arme = await _context.Armes.FirstOrDefaultAsync(a => a.Id == samouraiVM.IdArme);*/
                _context.Add(samouraiVM.Samourai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samouraiVM);
        }

        // GET: Samourais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samourai = await _context.Samourais.FindAsync(id);
            if (samourai == null)
            {
                return NotFound();
            }
            var samouraiVM = new SamouraiVM {
                Samourai = samourai,
                ChoixArme = SelectListArmes()
            };
            //samouraiVM.IdArme = samourai.Arme?.Id;
            return View(samouraiVM);
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SamouraiVM samouraiVM)
        {
            if (id != samouraiVM.Samourai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samouraiVM.Samourai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamouraiExists(samouraiVM.Samourai.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(samouraiVM);
        }

        // GET: Samourais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samourai = await _context.Samourais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samourai == null)
            {
                return NotFound();
            }

            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var samourai = await _context.Samourais.FindAsync(id);
            _context.Samourais.Remove(samourai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamouraiExists(int id)
        {
            return _context.Samourais.Any(e => e.Id == id);
        }

        private SelectList SelectListArmes() {
            return new SelectList(_context.Armes, "Id", "Nom");
        }
    }
}
