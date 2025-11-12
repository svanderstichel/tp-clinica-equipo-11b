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
        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                //si es la primera vez que estoy cargando esta pantalla
                //precargo el desplegable de obra social
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

                // Configuracion si estamos modificando
                /*Si del objeto Request estoy trayendo el id*/
                string id = Request.QueryString["idPaciente"] != null ? Request.QueryString["idPaciente"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PacienteNegocio negocio = new PacienteNegocio();
                    Paciente seleccionado = (negocio.ListarPacientes(id))[0]; //porque la lista solo tiene un registro

                    //Precargo todos los campos
                    txbNombre.Text = seleccionado.Nombre;
                    txbApellido.Text = seleccionado.Apellido;
                    txbDNI.Text = seleccionado.DNI.ToString();
                    txbTelefono.Text = seleccionado.Telefono.ToString();
                    txbEmail.Text = seleccionado.Email;
                    txtFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("yyyy-MM-dd");
                    ddlObraSocial.SelectedValue = seleccionado.ObraSocial.IdObraSocial.ToString();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
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

                if (Request.QueryString["idPaciente"] != null)
                {
                    nuevo.IdPaciente = int.Parse(Request.QueryString["idPaciente"]);
                    negocio.Actualizar(nuevo);
                }
                else
                    negocio.Agregar(nuevo);


                Response.Redirect("Pacientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx", false);


        }

        protected void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminarPaciente.Checked)
                {
                    PacienteNegocio negocio = new PacienteNegocio();

                    //recupero el id de la sesion
                    int id = int.Parse(Request.QueryString["idPaciente"].ToString());

                    negocio.EliminarLogico(id);

                    Response.Redirect("Pacientes.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}