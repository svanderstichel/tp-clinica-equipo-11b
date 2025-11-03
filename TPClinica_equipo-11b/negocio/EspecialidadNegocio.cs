using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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

            datos.SetearConsulta("SELECT IdEspecialidad, Nombre, Descripcion FROM Especialidad  ");
            if (id != "") {

                datos.SetearConsulta("SELECT IdEspecialidad, Nombre, Descripcion FROM Especialidad where IdEspecialidad = @IdEspecialidad ");
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
                datos.SetearConsulta("INSERT INTO Especialidad (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)");
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

    }
}
