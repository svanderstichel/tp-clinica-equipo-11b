using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace web_clinica
{
    public partial class Especialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {  // alta de una nueva especialidad en la BD
            try
            {
                Especialidad nueva = new Especialidad();
                EspecialidadNegocio negocio =new EspecialidadNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Descripcion = txtDescripcion.Text;

                negocio.Agregar(nueva);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
            
        }
    }
}
        
    
