using Microsoft.AspNetCore.Identity;

namespace Hospital.Models
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public List<Doctor> Doctor { get; set; }

    }
}
