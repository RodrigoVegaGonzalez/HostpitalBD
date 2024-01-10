using Hospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.ViewModel;

namespace Hospital.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Horario_Doctor> Horario_Doctor { get; set; }

        public DbSet<Receta_Medica> Receta_Medica { get; set; }

        public DbSet<Receta_Medicina> Receta_Medicina { get; set; }

        public DbSet<Medicina> Medicina { get; set; }

        public DbSet<Recepcionista> Recepcionista { get; set; }

        public DbSet<Paciente> Paciente { get; set; }


        public DbSet<Cita> Cita { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public DbSet<Hospital.ViewModel.DoctorHorarioListaVM>? DoctorHorarioListaVM { get; set; }


    }
}

