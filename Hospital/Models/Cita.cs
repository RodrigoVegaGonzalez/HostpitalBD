using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Cita
    {
        [Key]
        public int ID_Cita { get; set; }
        public string Consultorio { get; set; }
        public bool Pagado { get; set; }

        public DateTime Horario { get; set; }

        [ForeignKey("Doctor")]
        public int ID_Doctor { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey("Receta_Medica")]
        public int ID_Receta_Medica { get; set; }

        public Receta_Medica Receta_Medica { get; set; }

        [ForeignKey("Paciente")]
        public int ID_Paciente { get; set; }

        public Paciente Paciente { get; set; }

        /*  [ForeignKey("Paciente")]
          public int ID_Paciente { get; set; }

          public Paciente Paciente { get; set; }*/

        public Factura Factura { get; set; }
    }

}
