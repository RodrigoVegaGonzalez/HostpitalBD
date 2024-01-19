using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Doctor
    {
        [Key]
        public int ID_Doctor { get; set; }
        public int Turno { get; set; }

        [ForeignKey("Usuario")]
        public string ID_Usuario{ get; set; }

        public Usuario Usuario { get; set; }

        public string Cedula { get; set; }

        public List<Horario_Doctor> Horario_Doctor { get; set; }

        public List<Receta_Medica> Receta_Medica { get; set; }

        [ForeignKey("Especialidad")]
        public int? ID_Especialidad { get; set; }

        public Especialidad Especialidad { get; set; }

        public List<Cita> Cita { get; set; }

        [ForeignKey("Consultorio")]
        public int? ID_Consultorio { get; set; }

        public Consultorio? Consultorio { get; set; }
    }
}
