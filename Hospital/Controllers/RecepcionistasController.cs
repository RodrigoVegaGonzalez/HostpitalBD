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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class RecepcionistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<IdentityUser> _userStore;
        // private readonly IUserEmailStore<IdentityUser> _emailStore;

        public RecepcionistasController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserStore<IdentityUser> userStore, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            //_emailStore = GetEmailStore();
            _signInManager = signInManager;
            //   _emailStore = emailStore;
        }

        // GET: Recepcionistas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recepcionista.Include(r => r.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recepcionistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recepcionista == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionista
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.ID_Recepcionista == id);
            if (recepcionista == null)
            {
                return NotFound();
            }

            return View(recepcionista);
        }

        // GET: Recepcionistas/Create
        public IActionResult Create()
        {
            ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Recepcionistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Turno,Nombre,Telefono,Email,Password")] UsuarioRecepcionistaVM UsuarioRecepcionista)
        {

            var user = new Usuario
            {
                Nombre = UsuarioRecepcionista.Nombre,
                Telefono = UsuarioRecepcionista.Telefono
            };

            await _userStore.SetUserNameAsync(user, UsuarioRecepcionista.Email, CancellationToken.None);
            // await _emailStore.SetEmailAsync(user, UsuarioDoctor.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, UsuarioRecepcionista.Password);
            var userId = await _userManager.GetUserIdAsync(user);
            if (result.Succeeded)
            {

                if (!await _roleManager.RoleExistsAsync("Recepcionista"))
                    await _roleManager.CreateAsync(new IdentityRole("Recepcionista"));

            }

            //await _userManager.AddToRoleAsync(user, "Recepcionista");
            await _userManager.AddToRoleAsync(user, "Recepcionista");
            var recepcionista = new Recepcionista
            {
                Turno = UsuarioRecepcionista.Turno,
                ID_Usuario = userId
            };

            _context.Add(recepcionista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id", recepcionista.ID_Usuario);
            return View(recepcionista);
        }

        // GET: Recepcionistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recepcionista == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionista.FindAsync(id);
            if (recepcionista == null)
            {
                return NotFound();
            }
            ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id", recepcionista.ID_Usuario);
            return View(recepcionista);
        }

        // POST: Recepcionistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Recepcionista,Turno,ID_Usuario")] Recepcionista recepcionista)
        {
            if (id != recepcionista.ID_Recepcionista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recepcionista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionistaExists(recepcionista.ID_Recepcionista))
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
            ViewData["ID_Usuario"] = new SelectList(_context.Usuario, "Id", "Id", recepcionista.ID_Usuario);
            return View(recepcionista);
        }

        // GET: Recepcionistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recepcionista == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionista
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.ID_Recepcionista == id);
            if (recepcionista == null)
            {
                return NotFound();
            }

            return View(recepcionista);
        }

        // POST: Recepcionistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recepcionista == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Recepcionista'  is null.");
            }
            var recepcionista = await _context.Recepcionista.FindAsync(id);
            if (recepcionista != null)
            {
                _context.Recepcionista.Remove(recepcionista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecepcionistaExists(int id)
        {
          return (_context.Recepcionista?.Any(e => e.ID_Recepcionista == id)).GetValueOrDefault();
        }
    }
}
