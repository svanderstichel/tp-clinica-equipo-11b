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
            if (Session["listaOS"] == null)
            {
                ObraSocialNegocio negocio = new ObraSocialNegocio();
                //guardo la lista de os en sesion
                Session.Add("listaOS", negocio.ListarObrasSociales());
            }
            ////la cargo desde sesion (memoria)
            dgvObraSocial.DataSource = Session["listaOS"];
            dgvObraSocial.DataBind();
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

            Response.Redirect("CrearObraSocial.aspx?id=" + id);
        }

        protected void dgvObraSocial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvObraSocial.PageIndex = e.NewPageIndex;
            dgvObraSocial.DataBind();
        }
    }
}