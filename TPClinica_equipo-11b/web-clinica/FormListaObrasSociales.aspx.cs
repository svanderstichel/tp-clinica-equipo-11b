using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class FormListaObrasSociales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ObraSocialNegocio negocio = new ObraSocialNegocio();
            dgvObraSocial.DataSource = negocio.ListarObrasSociales();
            dgvObraSocial.DataBind();
        }

        protected void btnAgregarOS_Click(object sender, EventArgs e)
        {
            Response.Redirect("ObrasSociales.aspx", false);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx", false);
        }
    }
}