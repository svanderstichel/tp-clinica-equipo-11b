using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class TurnoTrabajo
    {
        public int Id { get; set; }
        public int MedicoId { get; set; } 
        public string DiaSemana { get; set; } 
        public TimeSpan HoraEntrada { get; set; } //tipo TimeSpan: Se usa para almacenar y manipular diferencias de tiempo, como la hora de entrada y salida de un turno.
        public TimeSpan HoraSalida { get; set; }


    }
}
