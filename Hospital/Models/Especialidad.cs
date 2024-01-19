
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Especialidad
    {

        [Key]
        public int ID_Especialidad { get; set; }

        public string Nombre { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
