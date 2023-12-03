
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Receta_Medica
    {

        [Key]
        public int ID_Receta { get; set; }

        [Required]
        public string Especificaciones { get; set; }


        [ForeignKey("Doctor")]
        public int ID_Doctor { get; set; }

        public Cita Cita { get; set; }
    }
}
