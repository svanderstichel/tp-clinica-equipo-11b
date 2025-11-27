using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace web_clinica
{
    public partial class CrearPaciente : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }

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
                //si es la primera vez que estoy cargando esta pantalla
                //precargo el desplegable de obra social
                if (!IsPostBack)
                {
                    ObraSocialNegocio negocio = new ObraSocialNegocio();
                    List<ObraSocial> lista = negocio.ListarNombresObraSocial();
                 
                    //cargo el desplegable desde db
                    ddlObraSocial.DataSource = lista;
                    ddlObraSocial.DataValueField = "Nombre";
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
                    // ddlObraSocial.SelectedValue = seleccionado.ObraSocial.IdObraSocial.ToString();
                    ddlObraSocial.SelectedValue = seleccionado.ObraSocial.Nombre;

                    ObraSocialNegocio negocioOS = new ObraSocialNegocio();
                    var listaCobertura = negocioOS.ListarCoberturas(seleccionado.ObraSocial.Nombre);

                    ddlCobertura.DataSource = listaCobertura;
                    ddlCobertura.DataValueField = "IdObraSocial";
                    ddlCobertura.DataTextField = "Cobertura";
                    ddlCobertura.DataBind();

                    ddlCobertura.SelectedValue = seleccionado.ObraSocial.IdObraSocial.ToString();


                    if (seleccionado.Estado)
                    {
                        btnInactivar.Visible = true;
                        btnActivar.Visible = false;
                    }
                    else
                    {
                        btnActivar.Visible = true;
                        btnInactivar.Visible = false;
                    }

                }
                // Configuracion si un paciente se da de alta
                /*Si del objeto Request estoy trayendo el id*/
                Usuario usuario = (Usuario)Session["Usuario"];
                if (usuario.Tipo == TipoUsuario.Paciente && !IsPostBack)
                {
                    //Precargo y bloqueo el email

                    txbEmail.Text = usuario.Email;
                    txbEmail.ReadOnly = true;
                    txbEmail.CssClass = "form-control readonly-textbox";

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
                nuevo.ObraSocial.IdObraSocial = int.Parse(ddlCobertura.SelectedValue);

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

        protected void ddlObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //me guardo el id del valor seleccionado
            string nombreOS = ddlObraSocial.SelectedValue;

            ObraSocialNegocio negocio = new ObraSocialNegocio();
            var lista = negocio.ListarCoberturas(nombreOS);

            ddlCobertura.DataSource = lista;
            ddlCobertura.DataValueField = "IdObraSocial";
            ddlCobertura.DataTextField = "Cobertura";
            ddlCobertura.DataBind();
        }

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {

        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio negocio = new PacienteNegocio();
                int id = int.Parse(Request.QueryString["idPaciente"]);
                negocio.EliminarLogico(id, true);
                Response.Redirect("Pacientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio negocio = new PacienteNegocio();
                int id = int.Parse(Request.QueryString["idPaciente"]);
                negocio.EliminarLogico(id, false);
                Response.Redirect("Pacientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }

        }
    }
}


