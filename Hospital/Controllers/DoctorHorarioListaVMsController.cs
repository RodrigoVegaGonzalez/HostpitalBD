using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.ViewModel;

namespace Hospital.Controllers
{
    public class DoctorHorarioListaVMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorHorarioListaVMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoctorHorarioListaVMs
        public async Task<IActionResult> Index()
        {
              return _context.DoctorHorarioListaVM != null ? 
                          View(await _context.DoctorHorarioListaVM.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DoctorHorarioListaVM'  is null.");
        }

        // GET: DoctorHorarioListaVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorHorarioListaVM == null)
            {
                return NotFound();
            }

            var doctorHorarioListaVM = await _context.DoctorHorarioListaVM
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doctorHorarioListaVM == null)
            {
                return NotFound();
            }

            return View(doctorHorarioListaVM);
        }

        // GET: DoctorHorarioListaVMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorHorarioListaVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] DoctorHorarioListaVM doctorHorarioListaVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorHorarioListaVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorHorarioListaVM);
        }

        // GET: DoctorHorarioListaVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorHorarioListaVM == null)
            {
                return NotFound();
            }

            var doctorHorarioListaVM = await _context.DoctorHorarioListaVM.FindAsync(id);
            if (doctorHorarioListaVM == null)
            {
                return NotFound();
            }
            return View(doctorHorarioListaVM);
        }

        // POST: DoctorHorarioListaVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] DoctorHorarioListaVM doctorHorarioListaVM)
        {
            if (id != doctorHorarioListaVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorHorarioListaVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorHorarioListaVMExists(doctorHorarioListaVM.ID))
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
            return View(doctorHorarioListaVM);
        }

        // GET: DoctorHorarioListaVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorHorarioListaVM == null)
            {
                return NotFound();
            }

            var doctorHorarioListaVM = await _context.DoctorHorarioListaVM
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doctorHorarioListaVM == null)
            {
                return NotFound();
            }

            return View(doctorHorarioListaVM);
        }

        // POST: DoctorHorarioListaVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorHorarioListaVM == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DoctorHorarioListaVM'  is null.");
            }
            var doctorHorarioListaVM = await _context.DoctorHorarioListaVM.FindAsync(id);
            if (doctorHorarioListaVM != null)
            {
                _context.DoctorHorarioListaVM.Remove(doctorHorarioListaVM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorHorarioListaVMExists(int id)
        {
          return (_context.DoctorHorarioListaVM?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
