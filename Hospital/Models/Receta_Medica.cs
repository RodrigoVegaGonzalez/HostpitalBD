
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Receta_Medica
    {

        [Key]
        public int ID_Receta { get; set; }

        [Required]
        public string Diagnostico { get; set; }

        public DateTime Fecha { get; set; }

        public string Tratamiento { get; set; }

        public DateTime Duracion { get; set; }

        public string Especificaciones { get; set; }

        [ForeignKey("Doctor")]
        public int ID_Doctor { get; set; }

        public Doctor? Doctor { get; set; }

        [ForeignKey("Medicina")]
        public int ID_Medicina { get; set; }

        public Medicina? Medicina { get; set; }

        [ForeignKey("Cita")]
        public int ID_Cita { get; set; }
        public Cita? Cita { get; set; }
    }
}
