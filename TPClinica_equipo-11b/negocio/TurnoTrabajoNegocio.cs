using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using Microsoft.SqlServer.Server;

namespace negocio
{
    public class TurnoTrabajoNegocio
    {
        public List<TurnoTrabajo> Listar()
        {
             List<TurnoTrabajo> lista = new List<TurnoTrabajo>();
             AccesoDatos datos = new AccesoDatos(); // Usando  clase AccesoDatos

             try
             {

                 datos.SetearConsulta("SELECT IdTurnoTrabajo, DiasLaborales, HoraEntrada, HoraSalida FROM TurnoTrabajo");
                 datos.ejecutarLectura();

                 while (datos.Lector.Read())
                 {
                     TurnoTrabajo turno = new TurnoTrabajo();
                     turno.IdTurnoTrabajo = (int)datos.Lector["IdTurnoTrabajo"];
                     turno.HoraEntrada = (TimeSpan)datos.Lector["HoraEntrada"];
                     turno.HoraSalida = (TimeSpan)datos.Lector["HoraSalida"];

                     // Lógica clave para mapear DiasLaborales (String SQL -> List<DiaSemana)
                     string diasStr = datos.Lector["DiasLaborales"].ToString();
                     turno.DiasLaborales = ConvertirStringADiasSemana(diasStr);

                     lista.Add(turno);
                 }
                 return lista;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 datos.CerrarConexion();
             }
         }

         // Función auxiliar para convertir la cadena de la DB a la lista de Enum.
         private List<DiaSemana> ConvertirStringADiasSemana(string diasStr)
         {
             List<DiaSemana> dias = new List<DiaSemana>();
             // Asumiendo que los días se guardan como "1,2,3,4,5"
             string[] ids = diasStr.Split(',');

             foreach (string id in ids)
             {
                 if (int.TryParse(id.Trim(), out int diaId))
                 {
                     // Aseguramos que el ID se pueda convertir al enum
                     if (Enum.IsDefined(typeof(DiaSemana), diaId))
                     {
                         dias.Add((DiaSemana)diaId);
                     }
                 }
             }
             return dias;
         }
        }
    }






