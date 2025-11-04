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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                lblToast.Text = "Se ha logeado correctamente a la aplicación.";
                MostrarToast();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio datos = new UsuarioNegocio();

                string email = txtEmail.Text;
                string pass = txtPassword.Text;

                if(datos.LoginUsuario(email, pass)){
                    Usuario usuario = datos.LeerUsuario(email);
                    Session.Add("Usuario", usuario);
                    Response.Redirect("Default.aspx", false);

                    
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrectos.");
                    Response.Redirect("Error.aspx",false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx",false);
        }
        private void MostrarToast()
        {
            string script = @"
                            const toastEl = document.getElementById('" + panelToast.ClientID + @"');
                            const toast = new bootstrap.Toast(toastEl);
                            toast.show();";

            ClientScript.RegisterStartupScript(this.GetType(), "mostrarToast", script, true);
        }
    }

}