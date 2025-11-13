using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace web_clinica
{
    public partial class ListaEspecialidad : System.Web.UI.Page
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
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                dgvEspecialidad.DataSource = negocio.ListarEspecialidades();
                dgvEspecialidad.DataBind();
            }
        }

        protected void btnAgregarEsp_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEspecialidad.aspx", false);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx", false);
        }

        protected void dgvEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvEspecialidad.SelectedDataKey.Value.ToString();
            Response.Redirect("CrearEspecialidad.aspx?id=" + id);

        }

       

        protected void dgvEspecialidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvEspecialidad.PageIndex = e.NewPageIndex;
            dgvEspecialidad.DataBind();
        }
    }
}






        