using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            try
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                txtEmail.Text = usuario.Email;
                txtApellido.Text = usuario.Apellido;
                txtNombre.Text = usuario.Nombre;
                ddlRol.SelectedValue = ((int)usuario.Tipo).ToString();
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
        }
    }
}