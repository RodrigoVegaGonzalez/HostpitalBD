using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Factura
    {
        [Key]
        public int ID_Factura { get; set; }

        public decimal Precio_Consulta { get; set; }

        public decimal Otro_Servicios { get; set; }

        [ForeignKey("Cita")]
        public int ID_Cita { get; set; }

        public Cita Cita { get; set; }
    }
}
