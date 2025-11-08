using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace web_clinica
{
    public partial class CrearPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                //si es la primera vez que estoy cargando esta pantalla
                if (!IsPostBack)
                {
                    ObraSocialNegocio negocio = new ObraSocialNegocio();
                    List<ObraSocial> lista = negocio.ListarObrasSociales();
                    //desplegable desde db
                    ddlObraSocial.DataSource = lista;
                    ddlObraSocial.DataValueField = "IdObraSocial";
                    ddlObraSocial.DataTextField = "Nombre";
                    ddlObraSocial.DataBind();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Paciente nuevo = new Paciente();
                PacienteNegocio negocio = new PacienteNegocio();

                nuevo.Nombre = txbNombre.Text;
                nuevo.Apellido = txbApellido.Text;
                nuevo.Email = txbEmail.Text;
                nuevo.DNI = txbDNI.Text;
                nuevo.Telefono = txbTelefono.Text;
                nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                nuevo.ObraSocial = new ObraSocial();
                nuevo.ObraSocial.IdObraSocial = int.Parse(ddlObraSocial.SelectedValue);

                negocio.Agregar(nuevo);
                Response.Redirect("Pacientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }



        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {


        }
    }
}