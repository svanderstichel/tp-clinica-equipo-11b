using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        Medico = 1,
        Recepcionista = 2,
        Administrador = 3
    }
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public TipoUsuario Tipo { get; set; }

    }
}
