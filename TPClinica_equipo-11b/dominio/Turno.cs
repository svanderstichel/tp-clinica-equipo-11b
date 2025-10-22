using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum Estado
    {
        Nuevo = 1,
        Reprogramado = 2,
        Cancelado = 3,
        Ausente = 4,
        Cerrado = 5
    }
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public Estado Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
