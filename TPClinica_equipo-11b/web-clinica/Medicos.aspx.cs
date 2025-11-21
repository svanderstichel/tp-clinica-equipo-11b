
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

        protected void dgvMedicos_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            dgvMedicos.PageIndex = e.NewPageIndex;
            dgvMedicos.DataBind();
        }

        protected void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx", false);
        }

        protected void dgvMedicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Especialidades" ||
                e.CommandName == "Horario" ||
                e.CommandName == "Datos")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                string id = dgvMedicos.DataKeys[index].Value.ToString();

                switch (e.CommandName)
                {
                    case "Especialidades":
                        Response.Redirect("AsignarEspecialidad.aspx?id=" + id, false);
                        break;

                    case "Horario":
                        Response.Redirect("AsignarHorario.aspx?id=" + id, false);
                        break;

                    case "Datos":
                        Response.Redirect("CrearMedico.aspx?id=" + id, false);
                        break;
                }
            }
        }     
    }
}
        
        