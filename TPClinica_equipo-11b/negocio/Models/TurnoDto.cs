using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;

namespace negocio.Models
{
    public class TurnoDto
    {
            public int Id { get; set; }
            public string Especialidad { get; set; }
            public string Paciente { get; set; }
            public string Medico { get; set; }
            public DateTime Fecha { get; set; }
            public TimeSpan Hora { get; set; }
            public Estado Estado { get; set; }
            public string Observaciones { get; set; }
            public string FechaFormateada => Fecha.ToString("dd/MM/yyyy");
            public string HoraFormateada => Hora.ToString(@"hh\:mm");
    }
}