using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //mostrar el dgv
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }



                Usuario usuario = (Usuario)Session["Usuario"];
                PacienteNegocio negocio = new PacienteNegocio();

                if (usuario.Tipo == TipoUsuario.Paciente && negocio.LeerPaciente(usuario.Email))
                {
                    dgvPaciente.DataSource = negocio.ListarUsuarioTipoPaciente(usuario.Email);
                    dgvPaciente.DataBind();
                }   
                if (usuario.Tipo == TipoUsuario.Administrador || usuario.Tipo == TipoUsuario.Recepcionista)
                {
                    // dgvPaciente.DataSource = negocio.ListarPacientes();
                    ///
                    Session.Add("listaPacientes", negocio.ListarPacientes());
                    dgvPaciente.DataSource = Session["listaPacientes"];
                    dgvPaciente.DataBind();
                }
            }
        }

        protected void dgvPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guardo el id seleccionado
            var id = dgvPaciente.SelectedDataKey.Value.ToString();
            //envio el id como parametro en la URL para precargar los valores
            Response.Redirect("CrearPaciente.aspx?idPaciente=" + id, false);
        }

        protected void dgvPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPaciente.PageIndex = e.NewPageIndex;
            dgvPaciente.DataSource = negocio.ListarPacientes();

            dgvPaciente.DataBind();
        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPaciente.aspx", false);

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);

        }

        protected void btnObraSocial_Click(object sender, EventArgs e)
        {
            Response.Redirect("ObrasSociales.aspx", false);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Paciente> lista = (List<Paciente>)Session["listaPacientes"];
            List<Paciente> listaFiltrada = lista.FindAll(x => x.Apellido.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvPaciente.DataSource = listaFiltrada;
            dgvPaciente.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio negocio = new PacienteNegocio();
                string apellido = txtFiltro.Text.Trim();
                string estado = ddlEstado.SelectedValue;

                List<Paciente> listaFiltrada = negocio.filtrar(apellido, estado);

                dgvPaciente.DataSource = listaFiltrada;
                dgvPaciente.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void dgvPaciente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //evalua el valor del campo Estado, si es true asigna un badge success si  no asigna el badge danger.
                bool activo = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado"));
                Literal lt = (Literal)e.Row.FindControl("ltEstado");

                if (activo)
                    lt.Text = "<span class='badge bg-success'>Activo</span>";
                else
                    lt.Text = "<span class='badge bg-danger'>Inactivo</span>";
            }
        }
    }
}