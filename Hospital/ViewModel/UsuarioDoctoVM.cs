using Hospital.Areas.Identity.Pages.Account;
using Hospital.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.ViewModel
{
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
        public Usuario usuario { get; set; }

        public Doctor Doctor { get; set; }

        public RegisterModel RegisterModel { get; set; }

    }
}
