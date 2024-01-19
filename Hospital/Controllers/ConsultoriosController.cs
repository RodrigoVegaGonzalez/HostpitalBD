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
    public class ConsultoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultorios
        public async Task<IActionResult> Index()
        {
              return _context.Consultorio != null ? 
                          View(await _context.Consultorio.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Consultorio'  is null.");
        }

        // GET: Consultorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio
                .FirstOrDefaultAsync(m => m.ID_Consultorio == id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // GET: Consultorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Consultorio,Nombre,Direccion")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultorio);
        }

        // GET: Consultorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio.FindAsync(id);
            if (consultorio == null)
            {
                return NotFound();
            }
            return View(consultorio);
        }

        // POST: Consultorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Consultorio,Nombre,Direccion")] Consultorio consultorio)
        {
            if (id != consultorio.ID_Consultorio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultorioExists(consultorio.ID_Consultorio))
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
            return View(consultorio);
        }

        // GET: Consultorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio
                .FirstOrDefaultAsync(m => m.ID_Consultorio == id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // POST: Consultorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

           
            if (_context.Consultorio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Consultorio'  is null.");
            }

            var consultorio = await _context.Consultorio.FindAsync(id);
            var doctor = _context.Doctor.Where(u => u.ID_Consultorio.Equals(id)).FirstOrDefault();
            if (doctor != null)
            {
                ViewBag.Error = "No se puede eliminar, tiene un Doctor asociado";
                return View(consultorio);
            }
            if (consultorio != null)
            {
                _context.Consultorio.Remove(consultorio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultorioExists(int id)
        {
          return (_context.Consultorio?.Any(e => e.ID_Consultorio == id)).GetValueOrDefault();
        }
    }
}
