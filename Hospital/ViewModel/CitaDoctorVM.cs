using Hospital.Models;

namespace Hospital.ViewModel
{
    public class CitaDoctorVM
    {

        public bool Pagado { get; set; }

        public List<Paciente> PacienteNombre { get; set; }

        public List<string> Dia { get; set; }

        public List<string> Mes { get; set; }

        public List<Horario_Doctor> Horario { get; set; }
 

        public Doctor Doctor { get; set; }

        public Paciente Paciente { get; set; }

        public Cita Cita { get; set; }
    }
}
