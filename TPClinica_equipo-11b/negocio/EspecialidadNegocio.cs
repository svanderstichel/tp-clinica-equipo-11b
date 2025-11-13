using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;
using Microsoft.SqlServer.Server;

namespace negocio
{
    public class EspecialidadNegocio
    {

        public List<Especialidad> ListarEspecialidades(string id = "" )
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT IdEspecialidad, Nombre,  Descripcion, Estado FROM Especialidad WHERE Estado = 1 ");
            if (id != "") {

                datos.SetearConsulta("SELECT IdEspecialidad, Nombre, Descripcion, Estado FROM Especialidad where IdEspecialidad = @IdEspecialidad and Estado = 1");
                datos.setearParametro("@IdEspecialidad", id);
            }
            
            
            try
            {
                datos.ejecutarLectura();

                

                while (datos.Lector.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.IdEspecialidad = (int)datos.Lector["IdEspecialidad"];
                    esp.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    esp.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    //esp.Estado = bool.Parse (datos.Lector["Estado"].ToString()); no se muestra el estado en la web

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
        public void Agregar(Especialidad nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO Especialidad (Nombre, Descripcion, Estado) VALUES (@Nombre, @Descripcion,1)");
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Descripcion", nueva.Descripcion);

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

        public Especialidad BuscarporID (string id)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearConsulta("SELECT Nombre, Descripcion from Especialidad where IdEspecialidad=@IdEspecialidad");
            datos.setearParametro("@IdEspecialidad", id);

            try
            {
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad();

                    especialidad.IdEspecialidad = (int)datos.Lector["IdEspecialidad"];
                   especialidad.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    especialidad.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    

                    return especialidad;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Actualizar(Especialidad especialidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Especialidad SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IdEspecialidad = @IdEspecialidad");

                datos.setearParametro("@IdEspecialidad", especialidad.IdEspecialidad);
                datos.setearParametro("@Nombre", especialidad.Nombre);
                datos.setearParametro("@Descripcion", especialidad.Descripcion);

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


           public void Eliminar(int id) 
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM ESPECIALIDAD WHERE IdEspecialidad =  @Id");
                datos.setearParametro("@Id", id);
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
        public void EliminarLogico(int id, bool Estado = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("update Especialidad set Estado = @Estado Where IdEspecialidad = @IdEspecialidad");
                datos.setearParametro("@IdEspecialidad", id);
                datos.setearParametro("@Estado", Estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    }

