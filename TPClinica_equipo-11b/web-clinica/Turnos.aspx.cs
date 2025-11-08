using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace web_clinica
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }

            try
            {
                TurnoNegocio datos = new TurnoNegocio();
                Usuario usuario = (Usuario)Session["Usuario"];
                if (usuario.Tipo == TipoUsuario.Administrador || usuario.Tipo == TipoUsuario.Recepcionista)
                {
                    dgvTurnos.DataSource = datos.ListarTurnos();
                    dgvTurnos.DataBind();
                }else
                {
                    dgvTurnos.DataSource = datos.ListarTurnos(usuario);
                    dgvTurnos.DataBind();
                }
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTurno = (int)dgvTurnos.SelectedDataKey.Value;
        }

        protected void dgvTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idTurno = (int)dgvTurnos.DataKeys[e.RowIndex].Value;   
        }
    }
}