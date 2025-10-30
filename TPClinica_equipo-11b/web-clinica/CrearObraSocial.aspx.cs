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
    public partial class ObrasSociales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocial nueva = new ObraSocial();
                ObraSocialNegocio negocio = new ObraSocialNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Descripcion = txtDescripcion.Text;

                negocio.Agregar(nueva);
                Response.Redirect("ObrasSociales.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ObrasSociales.aspx", false);
        }
    }
}