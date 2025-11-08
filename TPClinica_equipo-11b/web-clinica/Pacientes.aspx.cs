using negocio;
using System;
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
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPaciente.DataSource = negocio.ListarPacientes();
            dgvPaciente.DataBind();
        }

        protected void dgvPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }
    }
}