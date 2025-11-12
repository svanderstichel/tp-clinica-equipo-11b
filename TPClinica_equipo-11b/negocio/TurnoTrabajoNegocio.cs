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

                    // funcion--->ConvertirStringADiasSemana(string diasStr)
                    //La función recibe el valor de la columna DiasLaborales de la BD, que es una cadena (string) "1,2,3"
                   

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
            //el método .Split(',') lo convierte array de strings: ["1", "2", "3"].
            
            string[] ids = diasStr.Split(',');
            //Por cada elemento dentro de la colección ids, ejecuta el código siguiente, y nombra a ese elemento actual como id
            foreach (string id in ids)
             {
                 if (int.TryParse(id.Trim(), out int diaId))
                {//int.TryParse(id.Trim(), convierte la subcadena (ej. "1") a un número entero (int).
                 //El .Trim() elimina cualquier espacio en blanco accidental.
                 // Aseguramos que el ID se pueda convertir al enum
                    if (Enum.IsDefined(typeof(DiaSemana), diaId)) //verificar que este número realmente existe como un valor dentro de tu enum DiaSemana
                    {
                         dias.Add((DiaSemana)diaId);
                     }
                 }
             }
             return dias;
         }
        public void Agregar(TurnoTrabajo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Convertir la List<DiaSemana> a una cadena ("1,2,3,4,5") para guardar en la base
                string diasStr = ConvertirDiasSemanaAString(nuevo.DiasLaborales);

                datos.SetearConsulta("INSERT INTO TurnoTrabajo (DiasLaborales, HoraEntrada, HoraSalida) VALUES (@DiasLaborales, @HoraEntrada, @HoraSalida)");

                datos.setearParametro("@DiasLaborales", diasStr);
                datos.setearParametro("@HoraEntrada", nuevo.HoraEntrada);
                datos.setearParametro("@HoraSalida", nuevo.HoraSalida);

                datos.ejecutarAccion();
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

        public void Actualizar(TurnoTrabajo turno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string diasStr = ConvertirDiasSemanaAString(turno.DiasLaborales);

                datos.SetearConsulta("UPDATE TurnoTrabajo SET DiasLaborales = @DiasLaborales, HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida WHERE IdTurnoTrabajo = @IdTurnoTrabajo");

                datos.setearParametro("@IdTurnoTrabajo", turno.IdTurnoTrabajo);
                datos.setearParametro("@DiasLaborales", diasStr);
                datos.setearParametro("@HoraEntrada", turno.HoraEntrada);
                datos.setearParametro("@HoraSalida", turno.HoraSalida);

                datos.ejecutarAccion();
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

        // Función auxiliar para convertir la lista de Enum a la cadena de la DB.
        private string ConvertirDiasSemanaAString(List<DiaSemana> dias)
        {
            if (dias == null || dias.Count == 0)
                return "";

            // Convierte cada Enum a su valor entero (1, 2, 3...) y los une con comas.
            return string.Join(",", dias.Select(d => (int)d));
        }
    }
    }






