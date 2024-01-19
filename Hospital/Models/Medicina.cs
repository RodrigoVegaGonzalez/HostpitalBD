
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Medicina
    {
        [Key]
        public int ID_Medicina { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool En_Existencia { get; set; }

        public Receta_Medica? Receta_Medica { get; set; }

    }
}
