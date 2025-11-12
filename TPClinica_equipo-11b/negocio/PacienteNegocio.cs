using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PacienteNegocio
    {
        public Paciente LeerPaciente(int idPaciente)
        {
            AccesoDatos datos = new AccesoDatos();
            Paciente paciente = new Paciente();

            try
            {
                datos.setearParametro("@IdPaciente", idPaciente);
                datos.SetearConsulta("SELECT p.IdPaciente, p.Nombre, p.Apellido, p.Email, p.DNI, p.Telefono, p.FechaNacimiento, os.Nombre as NombreOS" +
                                 " FROM Paciente as p " +
                                 "INNER JOIN ObraSocial as os  ON p.IdObraSocial = os.IdObraSocial WHERE IdPaciente = @IdPaciente");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    paciente.IdPaciente = (int)datos.Lector["IdPaciente"];
                    paciente.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    paciente.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    paciente.Email = Convert.ToString(datos.Lector["Email"]);
                    paciente.DNI = Convert.ToString(datos.Lector["DNI"]);
                    paciente.Telefono = Convert.ToString(datos.Lector["Telefono"]);
                    paciente.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    paciente.ObraSocial = new ObraSocial();
                    paciente.ObraSocial.Nombre = Convert.ToString(datos.Lector["NombreOS"]);

                    return paciente;
                }

                return paciente;
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
        public List<Paciente> ListarPacientes(string id = "")
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT p.IdPaciente, p.Nombre, p.Apellido, p.Email, p.DNI, p.Telefono, p.FechaNacimiento, os.Nombre as NombreOS" +
                                 " FROM Paciente as p " +
                                 "INNER JOIN ObraSocial as os ON p.IdObraSocial = os.IdObraSocial WHERE p.Activo = 1");
            if(id != "")
            {
                datos.SetearConsulta("SELECT p.IdPaciente, p.Nombre, p.Apellido, p.Email, p.DNI, p.Telefono, p.FechaNacimiento, os.Nombre as NombreOS" +
                                 " FROM Paciente as p " +
                                 "INNER JOIN ObraSocial as os ON p.IdObraSocial = os.IdObraSocial " +
                                 "WHERE p.Activo = 1 and p.IdPaciente =  " + id);
            }
            try
            {
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.IdPaciente = (int)datos.Lector["IdPaciente"];
                    paciente.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    paciente.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    paciente.Email = Convert.ToString(datos.Lector["Email"]);
                    paciente.DNI = Convert.ToString(datos.Lector["DNI"]);
                    paciente.Telefono = Convert.ToString(datos.Lector["Telefono"]);
                    paciente.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    paciente.ObraSocial = new ObraSocial();
                    paciente.ObraSocial.Nombre = Convert.ToString(datos.Lector["NombreOS"]);

                    lista.Add(paciente);
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

        public void Agregar(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO Paciente (Nombre, Apellido, Email, DNI, Telefono, FechaNacimiento, IdObraSocial, Activo) VALUES (@Nombre, @Apellido, @Email, @DNI, @Telefono, @FechaNacimiento, @IdObraSocial, 1)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@FechaNacimiento", nuevo.FechaNacimiento);
                datos.setearParametro("@IdObraSocial", nuevo.ObraSocial.IdObraSocial);

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

        public void Actualizar(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Paciente SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, DNI = @DNI, Telefono = @Telefono, FechaNacimiento = @FechaNacimiento, IdObraSocial = @IdObraSocial " +
                    "WHERE IdPaciente = @IdPaciente");

                datos.setearParametro("@IdPaciente", paciente.IdPaciente);
                datos.setearParametro("@Nombre", paciente.Nombre);
                datos.setearParametro("@Apellido", paciente.Apellido);
                datos.setearParametro("@Email", paciente.Email);
                datos.setearParametro("@DNI", paciente.DNI);
                datos.setearParametro("@Telefono", paciente.Telefono);
                datos.setearParametro("@FechaNacimiento", paciente.FechaNacimiento);
                datos.setearParametro("@IdObraSocial", paciente.ObraSocial.IdObraSocial);

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
        public void EliminarLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("update Paciente set Activo = @activo Where IdPaciente = @idPaciente");
                datos.setearParametro("@IdPaciente", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
