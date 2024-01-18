using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public List<Doctor> Doctor { get; set; }

        public List<Recepcionista> Recepcionista { get; set; }

        public List<Paciente> Paciente { get; set; }

        [Required(ErrorMessage = "El campo CURP es obligatorio.")]
        [RegularExpression(@"^[A-Z]{4}[0-9]{6}[HM]{1}[A-Z]{5}[0-9]{2}$", ErrorMessage = "El formato de CURP no es válido.")]
        public string CURP { get; set; }

    }
}
