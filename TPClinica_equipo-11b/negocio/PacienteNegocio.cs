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
        public List<Paciente> ListarPacientes(string id = "")
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT p.IdPaciente, p.Nombre, p.Apellido, p.Email, p.DNI, p.Telefono, p.FechaNacimiento, os.Nombre as NombreOS" +
                                 " FROM Paciente as p " +
                                 "INNER JOIN ObraSocial as os  ON p.IdObraSocial = os.IdObraSocial");

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
                datos.SetearConsulta("INSERT INTO Paciente (Nombre, Apellido, Email, DNI, Telefono, FechaNacimiento, IdObraSocial) VALUES (@Nombre, @Apellido, @Email, @DNI, @Telefono, @FechaNacimiento, @IdObraSocial)");
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

    }
}
