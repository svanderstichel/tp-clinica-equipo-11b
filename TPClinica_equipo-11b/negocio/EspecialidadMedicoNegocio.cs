using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EspecialidadMedicoNegocio
    {
                   
            // (Devuelve las especialidades que ya tiene asignadas el médico)
            public List<MedicoEspecialidad> ListarPorMedico(int idMedico)
            {
                List<MedicoEspecialidad> lista = new List<MedicoEspecialidad>();
                AccesoDatos datos = new AccesoDatos(); 

                try
                {
                    // Incluimos IdMedicoEspecialidad en el SELECT
                    datos.SetearConsulta("SELECT ME.IdMedicoEspecialidad, ME.IdEspecialidad, E.Nombre FROM MedicoEspecialidad ME INNER JOIN Especialidad E ON E.IdEspecialidad = ME.IdEspecialidad WHERE ME.IdMedico = @IdMedico");
                    datos.setearParametro("@IdMedico", idMedico);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        MedicoEspecialidad me = new MedicoEspecialidad();

                        // Leemos el nuevo ID
                        me.IdMedicoEspecialidad = (int)datos.Lector["IdMedicoEspecialidad"];

                        me.IdMedico = idMedico; 
                        me.IdEspecialidad = (int)datos.Lector["IdEspecialidad"];
                        //me.NombreEspecialidad = datos.Lector["Nombre"].ToString();

                        lista.Add(me);
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar especialidades del médico.", ex);
                }
                finally
                {
                    datos.CerrarConexion();
                }
            }

            // 2. ASIGNAR UNA ESPECIALIDAD A UN MÉDICO (INSERT)
            public void Asignar(int idMedico, int idEspecialidad)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    
                    datos.SetearConsulta("INSERT INTO MedicoEspecialidad (IdMedico, IdEspecialidad) VALUES (@IdMedico, @IdEspecialidad)");
                    datos.setearParametro("@IdMedico", idMedico);
                    datos.setearParametro("@IdEspecialidad", idEspecialidad);
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error al asignar especialidad.", ex);
                }
                finally
                {
                    datos.CerrarConexion();
                }
            }

            
            public void Desasignar(int idMedico, int idEspecialidad)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    
                    datos.SetearConsulta("DELETE FROM MedicoEspecialidad WHERE IdMedico = @IdMedico AND IdEspecialidad = @IdEspecialidad");
                    datos.setearParametro("@IdMedico", idMedico);
                    datos.setearParametro("@IdEspecialidad", idEspecialidad);
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al desasignar especialidad.", ex);
                }
                finally
                {
                    datos.CerrarConexion();
                }
            }
        public void EliminarTodasPorMedico(int idMedico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta SQL para eliminar TODAS las filas de MedicoEspecialidad para un médico dado
                datos.SetearConsulta("DELETE FROM MedicoEspecialidad WHERE IdMedico = @IdMedico");
                datos.setearParametro("@IdMedico", idMedico);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar todas las especialidades del médico.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // OPCIONAL: Eliminar asignaciones usando el ID de la tabla M:N
        public void EliminarAsignacionPorId(int idMedicoEspecialidad)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.SetearConsulta("DELETE FROM MedicoEspecialidad WHERE IdMedicoEspecialidad = @Id");
                    datos.setearParametro("@Id", idMedicoEspecialidad);
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la asignación por ID.", ex);
                }
                finally
                {
                    datos.CerrarConexion();
                }
            }
        }
    }


