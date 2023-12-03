using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hospital.Controllers
{
    public class CitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cita.Include(c => c.Doctor).Include(c => c.Paciente).Include(c => c.Receta_Medica);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Doctor)
                .Include(c => c.Paciente)
                .Include(c => c.Receta_Medica)
                .FirstOrDefaultAsync(m => m.ID_Cita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create

        [Authorize(Roles = "Recepcionista")]
        public IActionResult Create()
        {
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor");
            ViewData["ID_Paciente"] = new SelectList(_context.Paciente, "ID_Paciente", "ID_Paciente");
            ViewData["ID_Receta_Medica"] = new SelectList(_context.Receta_Medica, "ID_Receta", "Especificaciones");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Cita,Consultorio,Pagado,Horario,ID_Doctor,ID_Receta_Medica,ID_Paciente")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", cita.ID_Doctor);
            ViewData["ID_Paciente"] = new SelectList(_context.Paciente, "ID_Paciente", "ID_Paciente", cita.ID_Paciente);
            ViewData["ID_Receta_Medica"] = new SelectList(_context.Receta_Medica, "ID_Receta", "Especificaciones", cita.ID_Receta_Medica);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", cita.ID_Doctor);
            ViewData["ID_Paciente"] = new SelectList(_context.Paciente, "ID_Paciente", "ID_Paciente", cita.ID_Paciente);
            ViewData["ID_Receta_Medica"] = new SelectList(_context.Receta_Medica, "ID_Receta", "Especificaciones", cita.ID_Receta_Medica);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Cita,Consultorio,Pagado,Horario,ID_Doctor,ID_Receta_Medica,ID_Paciente")] Cita cita)
        {
            if (id != cita.ID_Cita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.ID_Cita))
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
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", cita.ID_Doctor);
            ViewData["ID_Paciente"] = new SelectList(_context.Paciente, "ID_Paciente", "ID_Paciente", cita.ID_Paciente);
            ViewData["ID_Receta_Medica"] = new SelectList(_context.Receta_Medica, "ID_Receta", "Especificaciones", cita.ID_Receta_Medica);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Doctor)
                .Include(c => c.Paciente)
                .Include(c => c.Receta_Medica)
                .FirstOrDefaultAsync(m => m.ID_Cita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cita == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cita'  is null.");
            }
            var cita = await _context.Cita.FindAsync(id);
            if (cita != null)
            {
                _context.Cita.Remove(cita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
          return (_context.Cita?.Any(e => e.ID_Cita == id)).GetValueOrDefault();
        }
    }
}
