using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Medico
    {
        public int IdMedico { get; set; }
        [DisplayName("Código Mèdico")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Matricula { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
       public string Telefono { get; set; }
        [DisplayName("Telèfono")]
        public string Email { get; set; }
    }
}
