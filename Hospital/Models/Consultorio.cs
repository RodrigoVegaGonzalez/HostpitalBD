using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.Models
{
    public class Consultorio
    {
        [Key]
        public int ID_Consultorio { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public Doctor? Doctor { get; set; }

    }
}
