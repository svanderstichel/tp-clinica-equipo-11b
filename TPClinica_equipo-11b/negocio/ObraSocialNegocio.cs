using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ObraSocialNegocio
    {
        public List<ObraSocial> ListarObrasSociales(string id = "") //Parametro opcional
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT IdObraSocial, Nombre, Descripcion, Cobertura, Estado FROM ObraSocial");
            //Si el ID no esta vacio, me traigo solamemte la os que mande por parametro
            if (id != "")
                datos.SetearConsulta("SELECT IdObraSocial, Nombre, Descripcion, Cobertura, Estado FROM ObraSocial where IdObraSocial = " + id);

            try
            {
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ObraSocial obra = new ObraSocial();
                    obra.IdObraSocial = (int)datos.Lector["IdObraSocial"];
                    obra.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    obra.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    obra.Cobertura = datos.Lector["Cobertura"].ToString();
                    obra.Estado = bool.Parse(datos.Lector["Estado"].ToString());

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
                if (ExisteObraSocial(nueva.Nombre, nueva.Cobertura))
                {
                    throw new Exception("Ya existe una obra social con ese nombre y cobertura.");
                }

                datos.SetearConsulta("INSERT INTO ObraSocial (Nombre, Descripcion, Cobertura,  Estado) VALUES (@Nombre, @Descripcion, @Cobertura, 1)");
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Descripcion", nueva.Descripcion);
                datos.setearParametro("@Cobertura", nueva.Cobertura);

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
                datos.SetearConsulta("UPDATE ObraSocial SET Nombre = @Nombre, Descripcion = @Descripcion, Cobertura = @Cobertura WHERE IdObraSocial = @IdObraSocial");
                datos.setearParametro("@IdObraSocial", obra.IdObraSocial);
                datos.setearParametro("@Nombre", obra.Nombre);
                datos.setearParametro("@Descripcion", obra.Descripcion);
                datos.setearParametro("@Cobertura", obra.Cobertura);

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
        public void EliminarLogico(int id, bool estado = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("update ObraSocial set Estado = @estado Where idObraSocial = @idObraSocial");
                datos.setearParametro("@idObraSocial", id);
                datos.setearParametro("@estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ObraSocial> ListarNombresObraSocial()
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT DISTINCT Nombre FROM ObraSocial WHERE Estado = 1");
            try
            {
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ObraSocial os = new ObraSocial();
                    os.Nombre = datos.Lector["Nombre"].ToString();
                    lista.Add(os);
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
        public List<ObraSocial> ListarCoberturas(string nombre)
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT IdObraSocial, Cobertura FROM ObraSocial WHERE Estado = 1 AND Nombre = @Nombre");
            datos.setearParametro("@Nombre", nombre);
            try
            {
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ObraSocial os = new ObraSocial();
                    os.IdObraSocial = (int)datos.Lector["IdObraSocial"];
                    os.Cobertura = datos.Lector["Cobertura"].ToString();
                    lista.Add(os);
                }

                datos.CerrarConexion();
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

        public List<ObraSocial> filtrar(string nombre, string estado)
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT IdObraSocial, Nombre, Descripcion, Cobertura, Estado FROM ObraSocial WHERE 1=1";

                if (nombre != "")
                {
                    consulta += " AND Nombre LIKE @nombre";
                    datos.setearParametro("@nombre", "%" + nombre + "%");

                }

                if (estado == "Activo")
                {
                    consulta += " AND Estado = 1";
                }
                if (estado == "Inactivo")
                {
                    consulta += " AND Estado = 0";
                }

                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ObraSocial os = new ObraSocial();
                    os.IdObraSocial = (int)datos.Lector["IdObraSocial"];
                    os.Nombre = datos.Lector["Nombre"].ToString();
                    os.Descripcion = datos.Lector["Descripcion"].ToString();
                    os.Cobertura = datos.Lector["Cobertura"].ToString();
                    os.Estado = Convert.ToBoolean(datos.Lector["Estado"]);

                    lista.Add(os);
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
        public bool ExisteObraSocial(string nombre, string cobertura)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT 1 FROM ObraSocial WHERE Nombre = @Nombre AND Cobertura = @Cobertura");
                datos.setearParametro("@Nombre", nombre);
                datos.setearParametro("@Cobertura", cobertura);

                datos.ejecutarLectura();
                return datos.Lector.Read(); // Devuelve true si encontró un registro
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



