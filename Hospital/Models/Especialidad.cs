
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Especialidad
    {

        [Key]
        public int Id_Especialidad { get; set; }

        public string Nombre { get; set; }
    }
}
