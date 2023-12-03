using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Horario_Doctor
    {
      
             
         [Key]
        public int ID_Horario_Doctor { get; set; }
        public bool Disponibilidad { get; set; }

        public string Dia_Hora_Inicio { get; set; }

        [ForeignKey("Doctor")]
        public int ID_Doctor { get; set; }

        public Doctor Doctor { get; set; }

    }
}
