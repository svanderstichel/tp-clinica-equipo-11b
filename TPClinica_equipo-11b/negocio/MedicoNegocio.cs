using dominio;
using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MedicoNegocio
    {
        public Medico LeerMedico(int idMedico)
        {
            Medico medico = new Medico();
            AccesoDatos datos = new AccesoDatos();

            datos.setearParametro("@IdMedico", idMedico);
            datos.SetearConsulta("SELECT M.IdMedico, M.Nombre, M.Apellido, M.Matricula, M.Email, M.Telefono, M.Estado FROM Medico M WHERE IdMedico = @IdMedico");
            try
            {
                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {
                    medico.IdMedico = (int)datos.Lector["IdMedico"];
                    medico.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    medico.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    medico.Matricula = Convert.ToString(datos.Lector["Matricula"]);
                    medico.Email = Convert.ToString(datos.Lector["Email"]);
                    medico.Telefono = Convert.ToString(datos.Lector["Telefono"]);
                    medico.TurnoTrabajo = new dominio.TurnoTrabajo();
                    medico.Estado = bool.Parse(datos.Lector["Estado"].ToString());

                    return medico;
                }

                return medico;
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
        public List<Medico> ListarMedicos(int idEspecialidad)
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            datos.setearParametro("@IdEspecialidad", idEspecialidad);
            datos.SetearConsulta("SELECT DISTINCT M.IdMedico, M.Nombre, M.Apellido, M.Matricula, M.Email, M.Telefono, M.Estado FROM Medico M INNER JOIN MedicoEspecialidad E ON M.IdMedico = E.IdMedico WHERE IdEspecialidad = @IdEspecialidad");

            try
            {
                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {
                    Medico medico = new Medico();
                    medico.IdMedico = (int)datos.Lector["IdMedico"];
                    medico.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    medico.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    medico.Matricula = Convert.ToString(datos.Lector["Matricula"]);
                    medico.Email = Convert.ToString(datos.Lector["Email"]);
                    medico.Telefono = Convert.ToString(datos.Lector["Telefono"]);
                    medico.TurnoTrabajo = new dominio.TurnoTrabajo();
                    medico.Estado = bool.Parse(datos.Lector["Estado"].ToString());
                    lista.Add(medico);
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
        public List<Medico> ListarMedicos(string id = "")
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT IdMedico, Nombre, Apellido, Matricula, Email,Telefono, IdTurnoTrabajo, Estado  FROM Medico ");
            
            if (id != "")
            {

                datos.SetearConsulta("SELECT IdMedico, Nombre, Apellido, Matricula, Email,Telefono, IdTurnoTrabajo, Estado FROM Medico where IdMedico = @IdMedico ");
                datos.setearParametro("@IdMedico", id);
            }



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
                    esp.TurnoTrabajo = new dominio.TurnoTrabajo();
                    esp.TurnoTrabajo.IdTurnoTrabajo = (int)datos.Lector["IdTurnoTrabajo"];
                    esp.Estado = bool.Parse(datos.Lector["Estado"].ToString());



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
                datos.SetearConsulta("UPDATE Medico SET Nombre = @Nombre, Apellido = @Apellido, Matricula = @Matricula,Email = @Email,Telefono= @Telefono,IdTurnoTrabajo = @IdTurnoTrabajo WHERE IdMedico = @IdMedico");
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
        public void EliminarMedico(int id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM Medico WHERE IdMedico =  @IdMedico");
                datos.setearParametro("@IdMedico", id);
                datos.ejecutarAccion();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
        public void EliminarLogico(int id, bool Estado=false)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Medico set Estado = @Estado  WHERE IdMedico =  @IdMedico");
                datos.setearParametro("@IdMedico", id);
                datos.setearParametro("@Estado", Estado);
                datos.ejecutarAccion();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

    }

}




