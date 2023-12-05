using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<IdentityUser> _userStore;
       // private readonly IUserEmailStore<IdentityUser> _emailStore;

        public DoctorsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserStore<IdentityUser> userStore, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
           //_emailStore = GetEmailStore();
            _signInManager = signInManager;
         //   _emailStore = emailStore;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doctor.Include(d => d.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.ID_Doctor == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        [Authorize(Roles = "Recepcionista")]
        public IActionResult Create()
        {
            ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Recepcionista")]
        public async Task<IActionResult> Create([Bind("ID_Doctor,Consultorio,Turno,Especialidad,Nombre,Telefono,Email,Password")]UsuarioDoctoVM UsuarioDoctor)
        {

            var user = new Usuario
            {
                Nombre = UsuarioDoctor.Nombre,
                Telefono = UsuarioDoctor.Telefono
            };

            await _userStore.SetUserNameAsync(user, UsuarioDoctor.Email, CancellationToken.None);
           // await _emailStore.SetEmailAsync(user, UsuarioDoctor.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, UsuarioDoctor.Password);
            var userId = await _userManager.GetUserIdAsync(user);

            if (result.Succeeded)
            {

                if (!await _roleManager.RoleExistsAsync("Recepcionista"))
                    await _roleManager.CreateAsync(new IdentityRole("Recepcionista"));
                if (!await _roleManager.RoleExistsAsync("Doctor"))
                    await _roleManager.CreateAsync(new IdentityRole("Doctor"));

                if (!await _roleManager.RoleExistsAsync("Paciente"))
                    await _roleManager.CreateAsync(new IdentityRole("Paciente"));
            }

                //await _userManager.AddToRoleAsync(user, "Recepcionista");
                await _userManager.AddToRoleAsync(user, "Doctor");
                var doctor = new Doctor
                {
                    Consultorio = UsuarioDoctor.Consultorio,
                    Turno = 1,
                    Especialidad = UsuarioDoctor.Especialidad,
                    ID_Usuario = userId

                };
              
                    _context.Add(doctor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                
                ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id", doctor.ID_Usuario);
                return View(doctor);
            }

            // GET: Doctors/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.Doctor == null)
                {
                    return NotFound();
                }

                var doctor = await _context.Doctor.FindAsync(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id", doctor.ID_Usuario);
                return View(doctor);
            }
        
        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Doctor,Consultorio,Turno,Especialidad,ID_Usuario")] Doctor doctor)
        {
            if (id != doctor.ID_Doctor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.ID_Doctor))
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
            ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id", doctor.ID_Usuario);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.ID_Doctor == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doctor'  is null.");
            }
            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctor.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
          return (_context.Doctor?.Any(e => e.ID_Doctor == id)).GetValueOrDefault();
        }

       
    }
}
