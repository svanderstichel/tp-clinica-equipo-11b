using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class ObraSocialNegocio
    {
        public List<ObraSocial> ListarObrasSociales()
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT IdObraSocial, Nombre, Descripcion FROM ObraSocial");

            try
            {
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ObraSocial obra = new ObraSocial();
                    obra.IdObraSocial = (int)datos.Lector["IdObraSocial"];
                    obra.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    obra.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);

                    lista.Add(obra);
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
        public void Agregar(ObraSocial nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO ObraSocial (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)");
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

        public void Actualizar(ObraSocial obra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE ObraSocial SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IdObraSocial = @IdObraSocial");
                datos.setearParametro("@IdObraSocial", obra.IdObraSocial);
                datos.setearParametro("@Nombre", obra.Nombre);
                datos.setearParametro("@Descripcion", obra.Descripcion);

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