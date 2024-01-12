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
        public async Task<IActionResult> Index()
        {
            var tPDojoContext = _context.Samourai.Include(s => s.Arme).Include(s => s.ArtsMartiaux);
            return View(await tPDojoContext.ToListAsync());
        }

        // GET: Samourais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Samourai == null)
            {
                return NotFound();
            }

            var samourai = await _context.Samourai
                .Include(s => s.Arme)
                .Include(s => s.ArtsMartiaux)
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
            SamouraiVM samouraiVm = new SamouraiVM(new Samourai(),
                new SelectList(_context.Arme, "Id", "Nom"),
                new SelectList(_context.ArtMartial, "Id", "Nom"));
            return View(samouraiVm);
        }

        // POST: Samourais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SamouraiVM samouraiVm)
        {
            if (ModelState.IsValid)
            {
                if (samouraiVm.IdsArtsMartiaux == null)
                    samouraiVm.Samourai.ArtsMartiaux = new List<ArtMartial>();
                else
                    samouraiVm.Samourai.ArtsMartiaux = _context.ArtMartial!.Where(a => samouraiVm.IdsArtsMartiaux.Contains(a.Id)).ToList();
                _context.Add(samouraiVm.Samourai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samouraiVm);
        }

        // GET: Samourais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Samourai == null)
            {
                return NotFound();
            }

            var samourai = _context.Samourai.Include(s => s.ArtsMartiaux).FirstOrDefault(s => s.Id == id);
            if (samourai == null)
            {
                return NotFound();
            }
            SamouraiVM samouraiVm = new SamouraiVM(samourai,
                new SelectList(_context.Arme, "Id", "Nom"),
                new SelectList(_context.ArtMartial, "Id", "Nom")
                );
            samouraiVm.IdsArtsMartiaux = samourai.ArtsMartiaux?.Select(a => a.Id).ToList();
            return View(samouraiVm);
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SamouraiVM samouraiVm)
        {
            if (id != samouraiVm.Samourai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (samouraiVm.IdsArtsMartiaux == null)
                        samouraiVm.Samourai.ArtsMartiaux = new List<ArtMartial>();
                    else
                        samouraiVm.Samourai.ArtsMartiaux = _context.ArtMartial!.Where(a => samouraiVm.IdsArtsMartiaux.Contains(a.Id)).ToList();
                    _context.Update(samouraiVm.Samourai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamouraiExists(samouraiVm.Samourai.Id))
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
            return View(samouraiVm);
        }

        // GET: Samourais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Samourai == null)
            {
                return NotFound();
            }

            var samourai = await _context.Samourai
                .Include(s => s.Arme)
                .Include(s => s.ArtsMartiaux)
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
            if (_context.Samourai == null)
            {
                return Problem("Entity set 'TPDojoContext.Samourai'  is null.");
            }
            var samourai = await _context.Samourai.FindAsync(id);
            if (samourai != null)
            {
                _context.Samourai.Remove(samourai);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamouraiExists(int id)
        {
          return (_context.Samourai?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
