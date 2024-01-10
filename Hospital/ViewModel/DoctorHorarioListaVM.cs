using Hospital.Models;

namespace Hospital.ViewModel
{
    public class DoctorHorarioListaVM
    {

        public int ID { get; set; }
        public Horario_Doctor Lunes { get; set; }

        public Horario_Doctor Martes { get; set; }

       public Horario_Doctor Miercoles { get; set; }

        public Horario_Doctor Jueves { get; set; }
    }
}
