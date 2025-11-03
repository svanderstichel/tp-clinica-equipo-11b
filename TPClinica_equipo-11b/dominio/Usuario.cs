using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        Administrador = 1,
        Recepcionista = 2,
        Medico = 3,
        Paciente = 4
    }
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pass { get; set; }
        public TipoUsuario Tipo { get; set; }

    }
}
