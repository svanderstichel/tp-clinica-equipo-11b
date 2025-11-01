using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace web_clinica
{
    public partial class CrearMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


            if (!IsPostBack)
            {
                //Cargar Turnos de Trabajo
                TurnoTrabajoNegocio turnoNegocio = new TurnoTrabajoNegocio();
                List<TurnoTrabajo> listaTurnos = turnoNegocio.Listar();

                ddlTurnoTrabajo.DataSource = listaTurnos;
                ddlTurnoTrabajo.DataTextField = "HoraEntrada";
                ddlTurnoTrabajo.DataValueField = "IdTurnoTrabajo";
                ddlTurnoTrabajo.DataBind();
            }


            
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearMedico.aspx", false);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // alta de una nuevo medico en la BD
            try
            {
                Medico nueva = new Medico();
                MedicoNegocio negocio = new MedicoNegocio();

                nueva.Nombre = textBox1.Text;
                nueva.Apellido = textBox2.Text;
                nueva.Matricula = textBox6.Text;
                nueva.Email = textBox3.Text;
                nueva.Telefono = textBox4.Text;
                
                //Asignar el ID del Turno SELECCIONADO**
                nueva.TurnoTrabajo = new TurnoTrabajo();
                nueva.TurnoTrabajo.IdTurnoTrabajo = int.Parse(ddlTurnoTrabajo.SelectedValue);




                negocio.Agregar(nueva);
                
                Response.Redirect("CrearMedico.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
                //redirigir a pantalla de error
            }
        }
    }
}
