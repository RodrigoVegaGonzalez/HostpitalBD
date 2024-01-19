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
            var applicationDbContext = _context.Receta_Medica
                .Include(r => r.Cita)
                .Include(r => r.Doctor)
                 .Include(r => r.Doctor.Usuario)
                .Include(r => r.Medicina);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexDoctor(int id)
        {
            var applicationDbContext = _context.Receta_Medica
                .Include(r => r.Cita)
                .Include(r => r.Doctor)
                 .Include(r => r.Doctor.Usuario)
                .Include(r => r.Medicina)
                .Where(u => u.ID_Doctor == id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Receta_Medica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receta_Medica == null)
            {
                return NotFound();
            }

            var receta_Medica = await _context.Receta_Medica
                .Include(r => r.Cita)
                .Include(r => r.Doctor)
                .Include(r => r.Medicina)
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
            ViewData["ID_Cita"] = new SelectList(_context.Cita, "ID_Cita", "ID_Cita");
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor");
            ViewData["ID_Medicina"] = new SelectList(_context.Medicina, "ID_Medicina", "Nombre");
            return View();
        }

        public IActionResult CreateCita(int id)
        {
            ViewBag.Id = id;
            ViewData["ID_Cita"] = new SelectList(_context.Cita.Where(u => u.ID_Cita == id), "ID_Cita", "ID_Cita");
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor");
            ViewData["ID_Medicina"] = new SelectList(_context.Medicina, "ID_Medicina", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCita([Bind("ID_Receta,Diagnostico,Tratamiento,Duracion,Especificaciones,ID_Doctor,ID_Medicina,ID_Cita")] Receta_Medica receta_Medica)
        {
            var doctor = _context.Cita.Where(u => u.ID_Cita == receta_Medica.ID_Cita).FirstOrDefault();
            Receta_Medica receta = new Receta_Medica()
            {
                Diagnostico = receta_Medica.Diagnostico,
                Fecha = DateTime.Now,
                Tratamiento = receta_Medica.Tratamiento,
                Duracion = receta_Medica.Duracion,
                Especificaciones = receta_Medica.Especificaciones,
                ID_Doctor = doctor.ID_Doctor,
                ID_Medicina = receta_Medica.ID_Medicina,
                ID_Cita = receta_Medica.ID_Cita
            };
            if (ModelState.IsValid)
            {
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cita"] = new SelectList(_context.Cita, "ID_Cita", "ID_Cita", receta_Medica.ID_Cita);
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", receta_Medica.ID_Doctor);
            ViewData["ID_Medicina"] = new SelectList(_context.Medicina, "ID_Medicina", "Nombre", receta_Medica.ID_Medicina);
            return View(receta_Medica);
        }

        // POST: Receta_Medica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Receta,Diagnostico,Tratamiento,Duracion,Especificaciones,ID_Doctor,ID_Medicina,ID_Cita")] Receta_Medica receta_Medica)
        {
            var doctor = _context.Cita.Where(u => u.ID_Cita == receta_Medica.ID_Cita).FirstOrDefault();
            Receta_Medica receta = new Receta_Medica()
            {
                Diagnostico = receta_Medica.Diagnostico,
                Fecha = DateTime.Now,
                Tratamiento = receta_Medica.Tratamiento,
                Duracion = receta_Medica.Duracion,
                Especificaciones = receta_Medica.Especificaciones,
                ID_Doctor = doctor.ID_Doctor,
                ID_Medicina = receta_Medica.ID_Medicina,
                ID_Cita = receta_Medica.ID_Cita
            };
            if (ModelState.IsValid)
            {
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cita"] = new SelectList(_context.Cita, "ID_Cita", "ID_Cita", receta_Medica.ID_Cita);
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", receta_Medica.ID_Doctor);
            ViewData["ID_Medicina"] = new SelectList(_context.Medicina, "ID_Medicina", "Nombre", receta_Medica.ID_Medicina);
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
            ViewData["ID_Cita"] = new SelectList(_context.Cita, "ID_Cita", "ID_Cita", receta_Medica.ID_Cita);
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", receta_Medica.ID_Doctor);
            ViewData["ID_Medicina"] = new SelectList(_context.Medicina, "ID_Medicina", "Nombre", receta_Medica.ID_Medicina);
            return View(receta_Medica);
        }

        // POST: Receta_Medica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Receta,Diagnostico,Fecha,Tratamiento,Duracion,Especificaciones,ID_Doctor,ID_Medicina,ID_Cita")] Receta_Medica receta_Medica)
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
            ViewData["ID_Cita"] = new SelectList(_context.Cita, "ID_Cita", "ID_Cita", receta_Medica.ID_Cita);
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", receta_Medica.ID_Doctor);
            ViewData["ID_Medicina"] = new SelectList(_context.Medicina, "ID_Medicina", "Nombre", receta_Medica.ID_Medicina);
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
                .Include(r => r.Cita)
                .Include(r => r.Doctor)
                .Include(r => r.Medicina)
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
