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
    public class Horario_DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Horario_DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Horario_Doctor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Horario_Doctor.Include(h => h.Doctor).Include(u => u.Doctor.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Horario_Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Horario_Doctor == null)
            {
                return NotFound();
            }

            var horario_Doctor = await _context.Horario_Doctor
                .Include(h => h.Doctor)
                .FirstOrDefaultAsync(m => m.ID_Horario_Doctor == id);
            if (horario_Doctor == null)
            {
                return NotFound();
            }

            return View(horario_Doctor);
        }

        // GET: Horario_Doctor/Create
        public IActionResult Create()
        {
            List<String> DiasSemana = new List<String> { "Lunes","Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            ViewBag.DiasSemana = DiasSemana;
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor");
            var doctores = _context.Doctor.Include(d => d.Usuario).ToList();
            ViewBag.Doctores = doctores;
            return View();
        }

        // POST: Horario_Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<bool> Disponibilidad, List<string> DiaSemana , List<TimeSpan> HoraInicio, List<TimeSpan> HoraFin, int ID_Doctor)
        {

           
            for (int i = 0; i < DiaSemana.Count; i++)
            {
                var horario_doctor = new Horario_Doctor()
                {
                    Disponibilidad = Disponibilidad[i],
                    DiaSemana = DiaSemana[i],
                    HoraInicio = HoraInicio[i],
                    HoraFin = HoraFin[i],
                    ID_Doctor = ID_Doctor
                };
                if (ModelState.IsValid)
                {
                    _context.Add(horario_doctor);
                    await _context.SaveChangesAsync();
                    
                }
               
            }
            return RedirectToAction(nameof(Index));

            //return View();
            //  ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", horario_Doctor.ID_Doctor);

        }

        // GET: Horario_Doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Horario_Doctor == null)
            {
                return NotFound();
            }

            var horario_Doctor = await _context.Horario_Doctor.FindAsync(id);
            if (horario_Doctor == null)
            {
                return NotFound();
            }
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", horario_Doctor.ID_Doctor);
            return View(horario_Doctor);
        }

        // POST: Horario_Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Horario_Doctor,Disponibilidad,DiaSemana,HoraInicio,HoraFin,ID_Doctor")] Horario_Doctor horario_Doctor)
        {
            if (id != horario_Doctor.ID_Horario_Doctor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario_Doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Horario_DoctorExists(horario_Doctor.ID_Horario_Doctor))
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
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor", horario_Doctor.ID_Doctor);
            return View(horario_Doctor);
        }

        // GET: Horario_Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Horario_Doctor == null)
            {
                return NotFound();
            }

            var horario_Doctor = await _context.Horario_Doctor
                .Include(h => h.Doctor)
                .FirstOrDefaultAsync(m => m.ID_Horario_Doctor == id);
            if (horario_Doctor == null)
            {
                return NotFound();
            }

            return View(horario_Doctor);
        }

        // POST: Horario_Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Horario_Doctor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Horario_Doctor'  is null.");
            }
            var horario_Doctor = await _context.Horario_Doctor.FindAsync(id);
            if (horario_Doctor != null)
            {
                _context.Horario_Doctor.Remove(horario_Doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Horario_DoctorExists(int id)
        {
          return (_context.Horario_Doctor?.Any(e => e.ID_Horario_Doctor == id)).GetValueOrDefault();
        }
    }
}
