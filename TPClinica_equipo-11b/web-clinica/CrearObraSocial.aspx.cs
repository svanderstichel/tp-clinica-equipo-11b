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

            if (Request.QueryString["id"] != null)
            {
                //obtengo el id de la url
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<ObraSocial> temporal = (List<ObraSocial>)Session["listaOS"];
                ObraSocial seleccionada =  temporal.Find(x => x.IdObraSocial == id);
                //precargo los datos
                txtNombre.Text = seleccionada.Nombre;
                txtDescripcion.Text = seleccionada.Descripcion;
                
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocial nueva = new ObraSocial();
                ObraSocialNegocio negocio = new ObraSocialNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Descripcion = txtDescripcion.Text;

                //me traigo de la sesion la lista de os

                List<ObraSocial> temporal = (List<ObraSocial>)Session["listaOS"];
                temporal.Add(nueva);

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