using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Cita
    {
        [Key]
        public int ID_Cita { get; set; }
        public bool Pagado { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Día { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set; }

        [ForeignKey("Doctor")]
        public int ID_Doctor { get; set; }

        public Doctor? Doctor { get; set; }

     

        public Receta_Medica? Receta_Medica { get; set; }

        [ForeignKey("Paciente")]
        public int ID_Paciente { get; set; }

        public Paciente? Paciente { get; set; }
        public Factura? Factura { get; set; }
    }

}
