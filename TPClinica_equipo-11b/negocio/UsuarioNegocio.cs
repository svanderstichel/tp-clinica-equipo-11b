using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public void CrearUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@pass", usuario.Pass);
                datos.setearParametro("@tipo", usuario.Tipo);
                datos.SetearConsulta("INSERT INTO Usuario (Email, Nombre, Apellido, Pass, Tipo) VALUES (@email, @nombre, @apellido, @pass, @tipo)");

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
        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Usuario SET " +
                                    "Nombre = @nombre, " +
                                    "Apellido = @apellido, " +
                                    "Pass = @pass, " +
                                    "Tipo = @tipo " +
                                    "WHERE Email = @email");

                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@pass", usuario.Pass);
                datos.setearParametro("@tipo", (int)usuario.Tipo);

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
        public Usuario LeerUsuario(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();

            try
            {
                datos.setearParametro("@email", email);
                datos.SetearConsulta("SELECT Email, Nombre, Apellido, Pass, Tipo FROM Usuario WHERE Email = @email");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Email = email;
                    usuario.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    usuario.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    usuario.Pass = Convert.ToString(datos.Lector["Pass"]);
                    usuario.Tipo = (TipoUsuario)Convert.ToInt32(datos.Lector["Tipo"]);

                    return usuario;
                }

                return usuario;
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
        public bool LoginUsuario(string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearParametro("@email", email);
                datos.setearParametro("@pass", pass);
                datos.SetearConsulta("SELECT Email  FROM Usuario WHERE Email = @email AND Pass = @pass");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }

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
        public void CambiarContraseña(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Usuario SET " +
                                    "Pass = @pass " +
                                    "WHERE Email = @email");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
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
