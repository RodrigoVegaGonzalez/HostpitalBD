using Hospital.Models;

namespace Hospital.ViewModel
{
    public class HorarioDoctorVM
    {
        public bool Disponibilidad { get; set; }

        public string DiaSemana { get; set; }


        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public Doctor Doctor { get; set; }
    }
}
