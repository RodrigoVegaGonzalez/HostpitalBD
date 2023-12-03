using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Recepcionista
    {

        [Key]
        public int ID_Recepcionista { get; set; }

        public int Turno { get; set; }

        [ForeignKey("Usuario")]
        public string ID_Usuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}
