
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
    public partial class Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            MedicoNegocio negocio = new MedicoNegocio();
            dgvMedicos.DataSource = negocio.ListarMedicos();
            dgvMedicos.DataBind();        
        }

        
       

        protected void btnAgregarMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearMedico.aspx", false);
        }

        protected void btnRegresarMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void dgvMedicos_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string id = dgvMedicos.SelectedDataKey.Value.ToString();
            Response.Redirect("CrearMedico.aspx?id=" + id);

        }

        protected void dgvMedicos_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            dgvMedicos.PageIndex = e.NewPageIndex;
            dgvMedicos.DataBind();
        }

        protected void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx", false);
        }
    }
}