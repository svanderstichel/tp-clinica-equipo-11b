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
                Usuario usuario = (Usuario)Session["Usuario"];
                if (usuario.Tipo == TipoUsuario.Administrador || usuario.Tipo == TipoUsuario.Recepcionista)
                {
                    TurnoNegocio datos = new TurnoNegocio();
                    dgvTurnos.DataSource = datos.ListarTurnos();
                    dgvTurnos.DataBind();

                }
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}