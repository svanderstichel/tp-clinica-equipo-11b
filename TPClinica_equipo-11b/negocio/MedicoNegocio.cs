using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using Microsoft.SqlServer.Server;

namespace negocio
{
    public class MedicoNegocio
    {
        public List<Medico> ListarMedicos(string id = "")
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT IdMedico, Nombre, Apellido, Matricula, Email,Telefono, IdTurnoTrabajo  FROM Medico ");
           //datos.SetearConsulta("SELECT IdMedico, Nombre, Apellido, Email,Telefono, IdTurnoTrabajo, IdEspecialidad FROM Medico ");
            try
            {
                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {
                    Medico esp = new Medico();
                    esp.IdMedico= (int)datos.Lector["IdMedico"];
                    esp.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    esp.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    esp.Matricula = Convert.ToString(datos.Lector["Matricula"]);
                    esp.Email = Convert.ToString(datos.Lector["Email"]);
                    esp.Telefono= Convert.ToString(datos.Lector["Telefono"]);
                    esp.TurnoTrabajo.IdTurnoTrabajo = (int)datos.Lector["IdTurnoTrabajo"];
                    
                   

                    lista.Add(esp);
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
        public void Agregar(Medico nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO Medico (Nombre, Apellido,Matricula, Email, Telefono, IdTurnoTrabajo) VALUES (   @Nombre,    @Apellido,    @Matricula,     @Email,     @Telefono, @IdTurnoTrabajo)");
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Apellido", nueva.Apellido);
                datos.setearParametro("@Matricula", nueva.Matricula);
                datos.setearParametro("@Email", nueva.Email);
                datos.setearParametro("@Telefono", nueva.Telefono);
                datos.setearParametro("@IdTurnoTrabajo", nueva.TurnoTrabajo.IdTurnoTrabajo);


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

        

        public void Actualizar(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Medico SET Nombre = '@Nombre', Apellido = '@Apellido', Matricula = '@Matricula',Email = '@Email',Telefono= '@Telefono',IdTurnoTrabajo = '@IdTurnoTrabajo' WHERE IdMedico = '@IdMedico'");
                datos.setearParametro("@IdMedico", medico.IdMedico);
                datos.setearParametro("@Nombre", medico.Nombre);
                datos.setearParametro("@Apellido", medico.Apellido);
                datos.setearParametro("@Matricula", medico.Matricula);
                datos.setearParametro("@Email", medico.Email);
                datos.setearParametro("@Telefono", medico.Telefono);
                datos.setearParametro("@IdTurnoTrabajo", medico.TurnoTrabajo.IdTurnoTrabajo);


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

    }


}

