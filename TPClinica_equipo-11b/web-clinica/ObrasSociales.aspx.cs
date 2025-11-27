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
    public partial class FormListaObrasSociales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    Session.Add("listaOS", negocio.ListarObrasSociales());
                    dgvObraSocial.DataSource = Session["listaOS"];
                    dgvObraSocial.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
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
            Response.Redirect("CrearObraSocial.aspx?id=" + id, false);
        }

        protected void dgvObraSocial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ObraSocialNegocio negocio = new ObraSocialNegocio();
            dgvObraSocial.PageIndex = e.NewPageIndex;
            dgvObraSocial.DataSource = negocio.ListarObrasSociales();
            dgvObraSocial.DataBind();
        }

        protected void txtFiltroOS_TextChanged(object sender, EventArgs e)
        {
            List<ObraSocial> lista = (List<ObraSocial>)Session["listaOS"];
            List<ObraSocial> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroOS.Text.ToUpper()));
            dgvObraSocial.DataSource = listaFiltrada;
            dgvObraSocial.DataBind();
        }
        protected void dgvObraSocial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool activo = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado"));

                Literal lt = (Literal)e.Row.FindControl("ltEstado");
                if (lt != null)
                {
                    lt.Text = activo
                        ? "<span class='badge bg-success'>Activo</span>"
                        : "<span class='badge bg-danger'>Inactivo</span>";
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocialNegocio negocio = new ObraSocialNegocio();
                string nombre = txtFiltroOS.Text.Trim();
                string estado = ddlEstado.SelectedValue;

                dgvObraSocial.DataSource = negocio.filtrar(nombre, estado);
                dgvObraSocial.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }
    }
}