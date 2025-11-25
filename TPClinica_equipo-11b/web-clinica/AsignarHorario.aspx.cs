using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class AsignarHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // validacion de query string valido
                string idMedico = Request.QueryString["id"];

                if (string.IsNullOrEmpty(idMedico))
                {
                    Session.Add("Error", "No se seleccionó un médico.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
                try
                {
                    // precarga de formulario
                    MedicoNegocio datos = new MedicoNegocio();
                    Medico medico = datos.LeerMedico(int.Parse(idMedico));

                    txtMedico.Text = medico.Apellido + ", " + medico.Nombre;

                    if (medico.HoraEntrada != null)
                    {
                        ddlHoraEntrada.SelectedValue = medico.HoraEntrada.ToString(@"hh\:mm");
                    }
                    if(medico.HoraSalida != null)
                    {
                    ddlHoraSalida.SelectedValue = medico.HoraSalida.ToString(@"hh\:mm");
                    }
                    if (medico.DiasLaborales != null)
                    {
                        foreach (ListItem item in cboxDiasLaborales.Items)
                        {
                            int valor = int.Parse(item.Value);

                            if (medico.DiasLaborales.Contains((DiaSemana)valor))
                            {
                                item.Selected = true;
                            }
                        }
                    }
                } 
                catch(Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx", false);
                    return;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                // cargo datos para persistir en una nueva instancia de medico
                MedicoNegocio datos = new MedicoNegocio();
                Medico medico = new Medico();
                medico.IdMedico = int.Parse(Request.QueryString["id"]);
                medico.HoraEntrada = TimeSpan.Parse(ddlHoraEntrada.SelectedValue);
                medico.HoraSalida = TimeSpan.Parse(ddlHoraSalida.SelectedValue);


                foreach (ListItem item in cboxDiasLaborales.Items)
                {
                    if (item.Selected)
                    {
                        if (medico.DiasLaborales == null)
                        {
                            medico.DiasLaborales = new List<DiaSemana>();
                        }
                        medico.DiasLaborales.Add((DiaSemana)int.Parse(item.Value));
                    }
                }
                // se guardan los datos en la base de datos
                datos.modificarHorario(medico);
                Response.Redirect("Medicos.aspx", false);
            }
                catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }
    }
}