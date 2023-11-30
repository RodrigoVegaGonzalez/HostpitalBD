using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Doctor
    {
        [Key]
        public int ID_Doctor { get; set; }
        public string Consultorio { get; set; }
        public int Turno { get; set; }
        public string Especialidad { get; set; }

        [ForeignKey("Usuario")]
        public string ID_Usuario{ get; set; }

        public Usuario Usuario { get; set; }
    }
}
