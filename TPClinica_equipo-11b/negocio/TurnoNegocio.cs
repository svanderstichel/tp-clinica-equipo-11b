using dominio;
using negocio.Models;
using System;
using System.Collections.Generic;
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
            datos.SetearConsulta("SELECT \r\nIdTurno as id, \r\nEspecialidad.Nombre as Especialidad, \r\nPaciente.Apellido + ', ' + Paciente.Nombre as Paciente, \r\nMedico.Apellido + ', ' + Medico.Nombre as Medico, \r\nFecha, \r\nHora, \r\nEstado, \r\nObservaciones \r\nFROM Turno\r\nINNER JOIN Paciente\r\nON Turno.IdPaciente = Paciente.IdPaciente\r\nINNER JOIN Medico\r\nON turno.IdMedico = Medico.IdMedico \r\nINNER JOIN Especialidad\r\nON Turno.IdEspecialidad = Especialidad.IdEspecialidad");
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
                if(usuario.Tipo== TipoUsuario.Medico)
                {
                datos.SetearConsulta("SELECT \r\nIdTurno as id, \r\nEspecialidad.Nombre as Especialidad, \r\nPaciente.Apellido + ', ' + Paciente.Nombre as Paciente, \r\nMedico.Apellido + ', ' + Medico.Nombre as Medico, \r\nFecha, \r\nHora, \r\nEstado, \r\nObservaciones \r\nFROM Turno\r\nINNER JOIN Paciente\r\nON Turno.IdPaciente = Paciente.IdPaciente\r\nINNER JOIN Medico\r\nON turno.IdMedico = Medico.IdMedico \r\nINNER JOIN Especialidad\r\nON Turno.IdEspecialidad = Especialidad.IdEspecialidad WHERE Medico.Email = @email");
                }
                if (usuario.Tipo == TipoUsuario.Paciente)
                {
                    datos.SetearConsulta("SELECT \r\nIdTurno as id, \r\nEspecialidad.Nombre as Especialidad, \r\nPaciente.Apellido + ', ' + Paciente.Nombre as Paciente, \r\nMedico.Apellido + ', ' + Medico.Nombre as Medico, \r\nFecha, \r\nHora, \r\nEstado, \r\nObservaciones \r\nFROM Turno\r\nINNER JOIN Paciente\r\nON Turno.IdPaciente = Paciente.IdPaciente\r\nINNER JOIN Medico\r\nON turno.IdMedico = Medico.IdMedico \r\nINNER JOIN Especialidad\r\nON Turno.IdEspecialidad = Especialidad.IdEspecialidad WHERE Paciente.Email = @email");
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
    }
}
