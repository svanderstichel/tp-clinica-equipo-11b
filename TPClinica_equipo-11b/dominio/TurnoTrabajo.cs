using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum DiaSemana
    {
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5
    }
    public class TurnoTrabajo
    {
        public int IdTurnoTrabajo { get; set; }
        public List<DiaSemana> DiasLaborales { get; set; } 
        public TimeSpan HoraEntrada { get; set; } //tipo TimeSpan: Se usa para almacenar y manipular diferencias de tiempo, como la hora de entrada y salida de un turno.
        public TimeSpan HoraSalida { get; set; }
    }
}
