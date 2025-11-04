using System;
using dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace web_clinica
{
    public partial class CambioPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) { Response.Redirect("Default.aspx", false); return; }
            txtEmail.Text = ((Usuario)Session["Usuario"]).Email;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio datos = new UsuarioNegocio();

                string email = txtEmail.Text;
                Usuario usuario = datos.LeerUsuario(email);
                if(usuario.Pass == txtPassAnterior.Text)
                {
                    usuario.Pass = txtPassNueva.Text;
                    datos.CambiarContraseña(usuario);

                    panelToast.CssClass = "toast align-items-center text-bg-success border-0";
                    lblToast.Text = "Cambio de contraseña exitoso.";
                    MostrarToast();
                }
                else
                {
                    panelToast.CssClass = "toast align-items-center text-bg-danger border-0";
                    lblToast.Text = "Datos ingresados incorrectos.";
                    MostrarToast();
                }

            } 
                catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
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