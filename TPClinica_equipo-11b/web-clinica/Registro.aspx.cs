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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
            UsuarioNegocio datos = new UsuarioNegocio();
            Usuario usuario = new Usuario();

            usuario.Email = string.IsNullOrWhiteSpace(emailInput.Text) ? null : emailInput.Text;
            usuario.Apellido = string.IsNullOrWhiteSpace(apellidoInput.Text) ? null : apellidoInput.Text;
            usuario.Nombre = string.IsNullOrWhiteSpace(nombreInput.Text) ? null : nombreInput.Text;
            usuario.Pass = string.IsNullOrWhiteSpace(inputPassword.Text) ? null : inputPassword.Text;
            
            int valorSeleccionado = Convert.ToInt32(ddlRol.SelectedValue);
            
            if (valorSeleccionado != 0) {
                usuario.Tipo = (TipoUsuario)Convert.ToInt32(ddlRol.SelectedValue);
                datos.CrearUsuario(usuario);
                datos.LeerUsuario(usuario.Email);
                Session.Add("Usuario", usuario);
                Response.Redirect("Default.aspx", false);
            }

            else
            {
                throw new Exception();
            }
            
            }
            catch(Exception)
            {
                Session.Add("Error", "No se pudo registrar el usuario en la base de datos, faltan datos requeridos.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}