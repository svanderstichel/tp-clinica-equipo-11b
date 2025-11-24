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
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica que el usuario este loggeado
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }

            try
            {
                TurnoNegocio datos = new TurnoNegocio();
                Usuario usuario = (Usuario)Session["Usuario"];
                //verifica usuario administrador/recepcionista lista todos los turnos
                if (usuario.Tipo == TipoUsuario.Administrador || usuario.Tipo == TipoUsuario.Recepcionista)
                {
                    dgvTurnos.DataSource = datos.ListarTurnos();
                    dgvTurnos.DataBind();
                }else
                //verifica usuario medico/paciente lista turnos asociados
                {
                    dgvTurnos.DataSource = datos.ListarTurnos(usuario);
                    dgvTurnos.DataBind();
                }
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }
         
        //modificar turno
        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTurno = (int)dgvTurnos.SelectedDataKey.Value;
            TurnoNegocio datos = new TurnoNegocio();
            Turno turno = datos.LeerTurno(idTurno);
            Session.Add("Turno", turno);
            Response.Redirect("CrearTurno.aspx", false);
        }
        //eliminar turno
        protected void dgvTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idTurno = (int)dgvTurnos.DataKeys[e.RowIndex].Value;
            TurnoNegocio datos = new TurnoNegocio();
            datos.EliminarTurno(idTurno);
            Response.Redirect("Turnos.aspx", false);
        }
        //crear turno
        protected void BtnCrearTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearTurno.aspx", false);
        }
        //cambiar index dgv
        protected void dgvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvTurnos.PageIndex = e.NewPageIndex;
            dgvTurnos.DataBind();
        }
    }
}