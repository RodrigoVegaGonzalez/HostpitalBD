using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{

    public enum DiaSemana
    {
        Lunes,
        Martes,
        Miércoles,
        Jueves,
        Viernes,
        Sábado,
        Domingo
    }
    public class Horario_Doctor
    {
      
             
         [Key]
        public int ID_Horario_Doctor { get; set; }
        public bool Disponibilidad { get; set; }

        public string DiaSemana { get; set; }

       
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        [ForeignKey("Doctor")]
        public int ID_Doctor { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
