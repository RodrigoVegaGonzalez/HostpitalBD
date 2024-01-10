namespace Hospital.ViewModel
{
    public class CitaDoctorVM
    {
        public List<string> Doctor { get; set; }

        public List<string> Dia { get; set; }

        public List<string> Mes { get; set; }

        public List<TimeSpan> Horario { get; set; }

        public bool Pagado { get; set; }
    }
}
