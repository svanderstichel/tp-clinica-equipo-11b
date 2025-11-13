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
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            if (!IsPostBack)
            {
                ObraSocialNegocio negocio = new ObraSocialNegocio();
                dgvObraSocial.DataSource = negocio.ListarObrasSociales();
                dgvObraSocial.DataBind();
            }
        }

        protected void btnAgregarOS_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearObraSocial.aspx", false);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx", false);
        }

        protected void dgvObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guardo el id seleccionado
            var id = dgvObraSocial.SelectedDataKey.Value.ToString();
            //envio el id como parametro en la URL
            Response.Redirect("CrearObraSocial.aspx?id=" + id);
        }

        protected void dgvObraSocial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ObraSocialNegocio negocio = new ObraSocialNegocio();
            dgvObraSocial.PageIndex = e.NewPageIndex;
            dgvObraSocial.DataSource = negocio.ListarObrasSociales();
            dgvObraSocial.DataBind();
        }
    }
}