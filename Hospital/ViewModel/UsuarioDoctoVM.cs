using Hospital.Areas.Identity.Pages.Account;
using Hospital.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.ViewModel
{

    public enum DiaSemana
    {
        Lunes,
        Martes,
        Miércoles,
        Jueves,
        Viernes,
        Sábado,
        Domingo
    }
    public class UsuarioDoctoVM
    {
        
        public string Nombre { get; set; }

        public string Telefono { get; set; }
        public string Consultorio { get; set; }
        public int Turno { get; set; }
        public string Especialidad { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /*public bool Disponibilidad { get; set; }*/

      
       /* public TimeSpan HoraInicioLunes { get; set; }
        public TimeSpan HoraFinLunes { get; set; }

        public TimeSpan HoraInicioMartes{ get; set; }
        public TimeSpan HoraFinMartes { get; set; }

        public TimeSpan HoraInicioMiercoles { get; set; }
        public TimeSpan HoraFinJueves { get; set; }

        public TimeSpan HoraInicioViernes { get; set; }
        public TimeSpan HoraFinViernes { get; set; }

        public TimeSpan HoraInicioSabado { get; set; }
        public TimeSpan HoraFinSabado { get; set; }

        public TimeSpan HoraInicioDomingo { get; set; }
        public TimeSpan HoraFinDomingo { get; set; }*/
        public Usuario usuario { get; set; }

        public Doctor Doctor { get; set; }

       

        public RegisterModel RegisterModel { get; set; }

        public bool Disponibilidad { get; set; }

        


        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

    }
}
