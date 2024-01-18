using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class DiasDoctor
    {
        [Key]
        public int ID_DiasDoctor { get; set; }

        [ForeignKey("Doctor")]
        public int ID_Doctor { get; set; }

        public Doctor? Doctor { get; set; }

        public bool Disponibilidad { get; set; }

        public string Dia { get; set; }

        public List<Horas_Doctor> Horas_Doctor { get; set; }
    }
}
