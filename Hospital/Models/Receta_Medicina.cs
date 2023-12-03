using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Receta_Medicina
    {
        [Key]
        public int ID_Receta_Medicina { get; set; }

        [ForeignKey("Receta_Medica")]
        public int ID_Receta_Medica { get; set; }

        public Receta_Medica Receta_Medica { get; set; }
        public List<Medicina> Medicina { get; set; }
    }
}
