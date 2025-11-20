using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class AsignarEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MedicoNegocio negocio = new MedicoNegocio();

                try
                {

                    dgvEspeciliadadMedico.DataSource = negocio.ListarMedicos();
                    dgvEspeciliadadMedico.DataBind();


                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        
    
        protected void dgvEspeciliadadMedico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void dgvEspeciliadadMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }



        protected void btnVolverMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx", false);
        }

        protected void dgvEspeciliadadMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Obtener el ID del médico actual de la fila
                int idMedico = Convert.ToInt32(dgvEspeciliadadMedico.DataKeys[e.Row.RowIndex].Value);

                //Encontrar el CheckBoxList en la fila
                CheckBoxList cblEspecialidades = (CheckBoxList)e.Row.FindControl("cblEspecialidades");

                if (cblEspecialidades != null)
                {
                    EspecialidadNegocio espNegocio = new EspecialidadNegocio();
                    EspecialidadMedicoNegocio meNegocio = new EspecialidadMedicoNegocio();

                    // Cargar TODAS las especialidades en el CheckBoxList
                    cblEspecialidades.DataSource = espNegocio.ListarEspecialidades();
                    cblEspecialidades.DataBind();

                    // Obtener las especialidades ASIGNADAS a este médico
                    List<MedicoEspecialidad> asignadas = meNegocio.ListarPorMedico(idMedico);

                    // Marcar los CheckBoxes correspondientes
                    foreach (ListItem item in cblEspecialidades.Items)
                    {
                        // Buscar si el ID de este CheckBox existe en la lista de asignadas
                        if (asignadas.Any(me => me.IdEspecialidad.ToString() == item.Value))
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EspecialidadMedicoNegocio negocioME = new EspecialidadMedicoNegocio();

            try
            {
                // Iterar a través de cada fila del GridView
                foreach (GridViewRow row in dgvEspeciliadadMedico.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        // Obtener el ID del Médico (DataKey)
                        int idMedico = Convert.ToInt32(dgvEspeciliadadMedico.DataKeys[row.RowIndex].Value);

                        // Encontrar el CheckBoxList en la fila
                        CheckBoxList cbl = (CheckBoxList)row.FindControl("cblEspecialidades");

                        if (cbl != null)
                        {
                            //actualizar las asignaciones:
                            // Primero, eliminamos TODAS las asignaciones previas del médico.
                            negocioME.EliminarTodasPorMedico(idMedico); 

                            // Luego, recorremos el CheckBoxList para asignar solo las marcadas.
                            foreach (ListItem item in cbl.Items)
                            {
                                if (item.Selected)
                                {
                                    int idEspecialidadSeleccionada = Convert.ToInt32(item.Value);

                                    // Asignar la especialidad
                                    negocioME.Asignar(idMedico, idEspecialidadSeleccionada);
                                }
                            }
                        }
                    }
                }

                //  Recargar el GridView para asegurar que se muestre el estado guardado
                // Es importante hacer un DataBind completo después de guardar.
                MedicoNegocio negocio = new MedicoNegocio();
                dgvEspeciliadadMedico.DataSource = negocio.ListarMedicos();
                dgvEspeciliadadMedico.DataBind();

                
            }
            catch (Exception ex)
            {
                
                Session.Add("Error", "Error al guardar los cambios: " + ex.Message);
                // Response.Redirect("Error.aspx", false);
                throw;
            }
        }
    } }