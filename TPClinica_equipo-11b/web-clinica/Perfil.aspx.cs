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
            if (!IsPostBack)
            {
                try
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    txtEmail.Text = usuario.Email;
                    txtApellido.Text = usuario.Apellido;
                    txtNombre.Text = usuario.Nombre;
                    ddlRol.SelectedValue = ((int)usuario.Tipo).ToString();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio datos = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["Usuario"];
                
                usuario.Email = txtEmail.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Tipo = (TipoUsuario)Convert.ToInt32(ddlRol.SelectedValue);

                datos.ModificarUsuario(usuario);
                Session["Usuario"] = usuario;

                lblToast.Text = "Los cambios se han guardado correctamente.";
                MostrarToast();
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

        protected void btnPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPass.aspx", false);
        }
    }
}