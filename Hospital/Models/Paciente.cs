using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.Models
{
    public class Paciente
    {
        [Key]
        public int ID_Paciente { get; set; }

        [ForeignKey("Usuario")]
        public string ID_Usuario { get; set; }

        public Usuario Usuario { get; set; }
        public List<Cita> Citas { get; set; }



    }
}
    