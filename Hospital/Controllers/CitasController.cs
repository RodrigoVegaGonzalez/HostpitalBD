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
using Humanizer.Localisation.DateToOrdinalWords;

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
        public IActionResult Create(int id)
        {
            List<TimeSpan> Horas = new List<TimeSpan>();
            TimeSpan unaHora = new TimeSpan(1, 0, 0);
           // var HorarioDoctor = _context.Horario_Doctor.Where(u => u.ID_Doctor == id);
            //foreach(var u in HorarioDoctor)
            //{
                
            //    var HorasTotales = u.HoraFin - u.HoraInicio;
            //    for(var i = 0; i < HorasTotales.Hours; i++)
            //    {
            //        Horas.Add(u.HoraInicio + unaHora);
            //    }
           // }
            
            
            
           
            var NombreDoctor = _context.Doctor.Include(d => d.Usuario).ToList();
            var NombrePaciente = _context.Paciente.Include(d => d.Usuario).ToList();
            
            ViewData["Usuario"] = new SelectList(_context.Usuario, "Nombre", "Nombre");
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor");
            ViewData["ID_Paciente"] = new SelectList(_context.Paciente, "ID_Paciente", "ID_Paciente");
            ViewData["ID_Receta_Medica"] = new SelectList(_context.Receta_Medica, "ID_Receta", "Especificaciones");
            ViewBag.NombreDoctor = NombreDoctor;
            ViewBag.NombrePaciente = NombrePaciente;
          //  ViewBag.HorarioDoctor = HorarioDoctor;
            ViewBag.Horas = Horas;
            return View();
        }

      
        public IActionResult CreateCita(int? ID_Docto)
        {
           // var HorarioDoctor = _context.Horario_Doctor.ToList();
            var NombreDoctor = _context.Doctor.Include(d => d.Usuario).ToList();
            var NombrePaciente = _context.Paciente.Include(d => d.Usuario).ToList();
            ViewData["Usuario"] = new SelectList(_context.Usuario, "Nombre", "Nombre");
            ViewData["ID_Doctor"] = new SelectList(_context.Doctor, "ID_Doctor", "ID_Doctor");
            ViewData["ID_Paciente"] = new SelectList(_context.Paciente, "ID_Paciente", "ID_Paciente");
            ViewData["ID_Receta_Medica"] = new SelectList(_context.Receta_Medica, "ID_Receta", "Especificaciones");
            ViewBag.NombreDoctor = NombreDoctor;
            ViewBag.NombrePaciente = NombrePaciente;
           
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Cita,Pagado,Horario,ID_Doctor,ID_Paciente")] Cita cita)
        {
           //if (ModelState.IsValid)
            
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
              
            
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
