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
            
            EspecialidadNegocio negocio = new EspecialidadNegocio();
                

            if (!IsPostBack)
            {
                Session.Add("Lista Especialidad", negocio.ListarEspecialidadesDos());
                dgvEspecialidad.DataSource = Session["Lista Especialidad"];
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
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            dgvEspecialidad.DataSource = negocio.ListarEspecialidadesDos();
            dgvEspecialidad.DataBind();
        }

        protected void dgvEspecialidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                // Obtener el índice de la fila que se presionó.
                int index = Convert.ToInt32(e.CommandArgument);

                // Obtener el valor del DataKey (IdEspecialidad) usando el índice.
                
                string id = dgvEspecialidad.DataKeys[index].Value.ToString();

                // Redirigir a la página de modificación.
                Response.Redirect("CrearEspecialidad.aspx?id=" + id, false);
            }
        }

        protected void txtFiltroEspecialidad_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["Lista Especialidad"];
            List<Especialidad> listaFiltrar = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroEspecialidad.Text.ToUpper()));
            dgvEspecialidad.DataSource = listaFiltrar;
            dgvEspecialidad.DataBind();
        }
    }
}






        