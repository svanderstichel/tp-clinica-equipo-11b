using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class GestionarTurno
    {
 
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public int EspecialidadId { get; set; }
        public DateTime FechaTurno { get; set; }
        public TimeSpan HoraTurno { get; set; }
        public string EstadoTurno { get; set; } //(Ej: Nuevo, Reprogramado, Cancelado, NoAsistió, Cerrado)
        public string Observaciones { get; set; }
        public int NumeroTurno { get; set; }
    }
}
