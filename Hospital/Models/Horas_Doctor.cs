using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Horas_Doctor { 


        [Key]
        public int ID_Horas_Doctor { get; set; }

        public string Hora { get; set; }

        [ForeignKey("DiasDoctor")]
        public int ID_DiasDoctor { get; set; }

        public DiasDoctor DiasDoctor { get; set; }
    }
}
