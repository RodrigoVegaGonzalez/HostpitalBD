using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class Receta_MedicaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Receta_MedicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receta_Medica
        public async Task<IActionResult> Index()
        {
              return _context.Receta_Medica != null ? 
                          View(await _context.Receta_Medica.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Receta_Medica'  is null.");
        }

        // GET: Receta_Medica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receta_Medica == null)
            {
                return NotFound();
            }

            var receta_Medica = await _context.Receta_Medica
                .FirstOrDefaultAsync(m => m.ID_Receta == id);
            if (receta_Medica == null)
            {
                return NotFound();
            }

            return View(receta_Medica);
        }

        // GET: Receta_Medica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receta_Medica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Receta,Especificaciones,ID_Doctor")] Receta_Medica receta_Medica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receta_Medica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receta_Medica);
        }

        // GET: Receta_Medica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receta_Medica == null)
            {
                return NotFound();
            }

            var receta_Medica = await _context.Receta_Medica.FindAsync(id);
            if (receta_Medica == null)
            {
                return NotFound();
            }
            return View(receta_Medica);
        }

        // POST: Receta_Medica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Receta,Especificaciones,ID_Doctor")] Receta_Medica receta_Medica)
        {
            if (id != receta_Medica.ID_Receta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receta_Medica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Receta_MedicaExists(receta_Medica.ID_Receta))
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
            return View(receta_Medica);
        }

        // GET: Receta_Medica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receta_Medica == null)
            {
                return NotFound();
            }

            var receta_Medica = await _context.Receta_Medica
                .FirstOrDefaultAsync(m => m.ID_Receta == id);
            if (receta_Medica == null)
            {
                return NotFound();
            }

            return View(receta_Medica);
        }

        // POST: Receta_Medica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receta_Medica == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Receta_Medica'  is null.");
            }
            var receta_Medica = await _context.Receta_Medica.FindAsync(id);
            if (receta_Medica != null)
            {
                _context.Receta_Medica.Remove(receta_Medica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Receta_MedicaExists(int id)
        {
          return (_context.Receta_Medica?.Any(e => e.ID_Receta == id)).GetValueOrDefault();
        }
    }
}
