using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Festival.BO;
using Festival.Web.Data;
using Festival.Web.ViewModels;

namespace Festival.Web.Controllers
{
    public class ArtistesController : Controller
    {
        private readonly ApplicationContext _context;

        public ArtistesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Artistes
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Artiste.Include(a => a.Groupe);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Artistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artiste == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste
                .Include(a => a.Groupe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // GET: Artistes/Create
        public IActionResult Create()
        {
            ViewData["GroupeId"] = new SelectList(_context.Set<Groupe>(), "Id", "Nom");
            return View();
        }

        // POST: Artistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtisteViewModel artisteViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artisteViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupeId"] = new SelectList(_context.Set<Groupe>(), "Id", "Nom", artisteViewModel.GroupeId);
            return View(artisteViewModel);
        }

        // GET: Artistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artiste == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste.FindAsync(id);
            if (artiste == null)
            {
                return NotFound();
            }
            ViewData["GroupeId"] = new SelectList(_context.Set<Groupe>(), "Id", "Nom", artiste.GroupeId);
            return View(artiste);
        }

        // POST: Artistes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtisteViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ConvertViewModelToModel(viewModel));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtisteExists(viewModel.Id))
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
            ViewData["GroupeId"] = new SelectList(_context.Set<Groupe>(), "Id", "Nom", viewModel.GroupeId);
            return View(viewModel);
        }

        private static Artiste ConvertViewModelToModel(ArtisteViewModel viewModel)
        {
            return new Artiste()
            {
                Id = viewModel.Id,
                GroupeId = viewModel.GroupeId,
                Instrument = viewModel.Instrument,
                Nom = viewModel.Nom,
                Prenom = viewModel.Prenom,
            };
        }

        // GET: Artistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artiste == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste
                .Include(a => a.Groupe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // POST: Artistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artiste == null)
            {
                return Problem("Entity set 'ApplicationContext.Artiste'  is null.");
            }
            var artiste = await _context.Artiste.FindAsync(id);
            if (artiste != null)
            {
                _context.Artiste.Remove(artiste);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtisteExists(int id)
        {
          return (_context.Artiste?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
