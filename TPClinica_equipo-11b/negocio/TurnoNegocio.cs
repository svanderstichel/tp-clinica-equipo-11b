using dominio;
using negocio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class TurnoNegocio
    {
        public List<TurnoDto> ListarTurnos()
        {
            List<TurnoDto> listaTurnos = new List<TurnoDto>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.SetearConsulta("SELECT \r\nIdTurno as id, \r\nEspecialidad.Nombre as Especialidad, \r\nPaciente.Apellido + ', ' + Paciente.Nombre as Paciente, \r\nMedico.Apellido + ', ' + Medico.Nombre as Medico, \r\nFecha, \r\nHora, \r\nTurno.Estado, \r\nObservaciones \r\nFROM Turno\r\nINNER JOIN Paciente\r\nON Turno.IdPaciente = Paciente.IdPaciente\r\nINNER JOIN Medico\r\nON turno.IdMedico = Medico.IdMedico \r\nINNER JOIN Especialidad\r\nON Turno.IdEspecialidad = Especialidad.IdEspecialidad");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoDto turno = new TurnoDto();

                    turno.Id = Convert.ToInt32(datos.Lector["id"]);
                    turno.Estado = (Estado)Convert.ToInt32(datos.Lector["Estado"]);
                    turno.Especialidad = Convert.ToString(datos.Lector["Especialidad"]);
                    turno.Paciente = Convert.ToString(datos.Lector["Paciente"]);
                    turno.Medico = Convert.ToString(datos.Lector["Medico"]);
                    turno.Fecha = Convert.ToDateTime(datos.Lector["Fecha"]);
                    turno.Hora = (TimeSpan)datos.Lector["Hora"];
                    turno.Observaciones = Convert.ToString(datos.Lector["Observaciones"]);

                    listaTurnos.Add(turno);
                }

                return listaTurnos;
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
        public List<TurnoDto> ListarTurnos(Usuario usuario)
        {
            string email = usuario.Email;
            List<TurnoDto> listaTurnos = new List<TurnoDto>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                if (usuario.Tipo == TipoUsuario.Medico)
                {
                    datos.SetearConsulta("SELECT \r\nIdTurno as id, \r\nEspecialidad.Nombre as Especialidad, \r\nPaciente.Apellido + ', ' + Paciente.Nombre as Paciente, \r\nMedico.Apellido + ', ' + Medico.Nombre as Medico, \r\nFecha, \r\nHora, \r\nTurno.Estado, \r\nObservaciones \r\nFROM Turno\r\nINNER JOIN Paciente\r\nON Turno.IdPaciente = Paciente.IdPaciente\r\nINNER JOIN Medico\r\nON turno.IdMedico = Medico.IdMedico \r\nINNER JOIN Especialidad\r\nON Turno.IdEspecialidad = Especialidad.IdEspecialidad WHERE Medico.Email = @email");
                }
                if (usuario.Tipo == TipoUsuario.Paciente)
                {
                    datos.SetearConsulta("SELECT \r\nIdTurno as id, \r\nEspecialidad.Nombre as Especialidad, \r\nPaciente.Apellido + ', ' + Paciente.Nombre as Paciente, \r\nMedico.Apellido + ', ' + Medico.Nombre as Medico, \r\nFecha, \r\nHora, \r\nTurno.Estado, \r\nObservaciones \r\nFROM Turno\r\nINNER JOIN Paciente\r\nON Turno.IdPaciente = Paciente.IdPaciente\r\nINNER JOIN Medico\r\nON turno.IdMedico = Medico.IdMedico \r\nINNER JOIN Especialidad\r\nON Turno.IdEspecialidad = Especialidad.IdEspecialidad WHERE Paciente.Email = @email");
                }
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoDto turno = new TurnoDto();

                    turno.Id = Convert.ToInt32(datos.Lector["id"]);
                    turno.Estado = (Estado)Convert.ToInt32(datos.Lector["Estado"]);
                    turno.Especialidad = Convert.ToString(datos.Lector["Especialidad"]);
                    turno.Paciente = Convert.ToString(datos.Lector["Paciente"]);
                    turno.Medico = Convert.ToString(datos.Lector["Medico"]);
                    turno.Fecha = Convert.ToDateTime(datos.Lector["Fecha"]);
                    turno.Hora = (TimeSpan)datos.Lector["Hora"];
                    turno.Observaciones = Convert.ToString(datos.Lector["Observaciones"]);

                    listaTurnos.Add(turno);
                }

                return listaTurnos;
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
        public void EliminarTurno(int idTurno)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM Turno WHERE IdTurno =  @IdTurno");
                datos.setearParametro("@IdTurno", idTurno);
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

        public List<TimeSpan> TurnosOcupados(int idMedico, DateTime fecha)
        {
            List<TimeSpan> turnosOcupados = new List<TimeSpan>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearConsulta("SELECT Hora From Turno WHERE IdMedico = @IdMedico AND Fecha = @Fecha");
                datos.setearParametro("@IdMedico", idMedico);
                datos.setearParametro("@Fecha", fecha);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TimeSpan horaTurno = new TimeSpan();
                    horaTurno = (TimeSpan)datos.Lector["Hora"];
                    turnosOcupados.Add(horaTurno);
                }

                return turnosOcupados;
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
        public void CrearTurno(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearParametro("@IdPaciente", turno.IdPaciente);
                datos.setearParametro("@IdMedico", turno.IdMedico);
                datos.setearParametro("@IdEspecialidad", turno.IdEspecialidad);
                datos.setearParametro("@Fecha", turno.Fecha);
                datos.setearParametro("@Hora", turno.Hora);
                datos.setearParametro("@Observaciones", turno.Observaciones);
                datos.SetearConsulta("INSERT INTO Turno (IdPaciente, IdMedico, IdEspecialidad, Fecha, Hora, Observaciones, Estado)" +
                    "VALUES (@IdPaciente, @IdMedico, @IdEspecialidad, @Fecha, @Hora, @Observaciones, 1)");
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
        public void ModificarTurno(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearParametro("@IdTurno", turno.IdTurno);
                datos.setearParametro("@IdPaciente", turno.IdPaciente);
                datos.setearParametro("@IdMedico", turno.IdMedico);
                datos.setearParametro("@IdEspecialidad", turno.IdEspecialidad);
                datos.setearParametro("@Fecha", turno.Fecha);
                datos.setearParametro("@Hora", turno.Hora);
                datos.setearParametro("@Observaciones", turno.Observaciones);
                datos.SetearConsulta("UPDATE Turno SET IdPaciente = @IdPaciente," +
                    "IdMedico = @IdMedico," +
                    "IdEspecialidad = @IdEspecialidad," +
                    "Fecha = @Fecha," +
                    "Hora = @Hora," +
                    "Observaciones = @Observaciones" +
                    " WHERE IdTurno = @IdTurno");
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
        public Turno LeerTurno(int idTurno)
        {
            AccesoDatos datos = new AccesoDatos();
            Turno turno = new Turno();

            try
            {
                datos.setearParametro("@IdTurno", idTurno);
                datos.SetearConsulta("SELECT * FROM Turno WHERE IdTurno = @IdTurno");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    turno.IdTurno = Convert.ToInt32(datos.Lector["IdTurno"]);
                    turno.Estado = (Estado)Convert.ToInt32(datos.Lector["Estado"]);
                    turno.IdEspecialidad = Convert.ToInt32(datos.Lector["IdEspecialidad"]);
                    turno.IdPaciente = Convert.ToInt32(datos.Lector["IdPaciente"]);
                    turno.IdMedico = Convert.ToInt32(datos.Lector["IdMedico"]);
                    turno.Fecha = Convert.ToDateTime(datos.Lector["Fecha"]);
                    turno.Hora = (TimeSpan)datos.Lector["Hora"];
                    turno.Observaciones = Convert.ToString(datos.Lector["Observaciones"]);
                }
                return turno;
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
