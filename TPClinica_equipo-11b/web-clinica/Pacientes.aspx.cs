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
                    dgvPaciente.DataSource = negocio.ListarPacientes();
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
    }
}