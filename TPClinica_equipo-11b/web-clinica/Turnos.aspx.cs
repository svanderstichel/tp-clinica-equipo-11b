using dominio;
using negocio;
using negocio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (!IsPostBack)
            {
                try
                {
                    TurnoNegocio datos = new TurnoNegocio();
                    Usuario usuario = (Usuario)Session["Usuario"];
                    //verifica usuario administrador/recepcionista lista todos los turnos
                    if (usuario.Tipo == TipoUsuario.Administrador || usuario.Tipo == TipoUsuario.Recepcionista)
                    {
                        Session.Add("ListaTurnos", datos.ListarTurnos());
                        dgvTurnos.DataSource = Session["ListaTurnos"];
                        dgvTurnos.DataBind();

                        //cargo valores al filtro de estado de turno
                        FiltroEstado.Items.Clear();
                        foreach (var estado in Enum.GetValues(typeof(Estado)))
                        {
                            FiltroEstado.Items.Add(
                                new ListItem(estado.ToString(), estado.ToString())
                            );
                        }
                        FiltroEstado.Items.Insert(0, new ListItem("", ""));
                    }
                    else
                    //verifica usuario medico/paciente lista turnos asociados
                    {
                        dgvTurnos.DataSource = datos.ListarTurnos(usuario);
                        dgvTurnos.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx", false);
                }
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
            AplicarFiltros();
        }

        protected void FiltroPaciente_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        protected void FiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        protected void BtnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Turnos.aspx", false);
            } 
            catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
        //metodo para asignar estilo a los estados de turno segun su valor
        protected void dgvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = e.Row.Cells[0].Text.Trim();
                string css = "";

                switch (estado)
                {
                    case "Nuevo":
                        css = "badge bg-primary";
                        break;
                    case "Reprogramado":
                        css = "badge bg-warning text-dark";
                        break;
                    case "Cancelado":
                        css = "badge bg-danger";
                        break;
                    case "Ausente":
                        css = "badge bg-secondary";
                        break;
                    case "Cerrado":
                        css = "badge bg-success";
                        break;
                }
                e.Row.Cells[0].Text = $"<span class='{css}'>{estado}</span>";
            }
        }
        private void AplicarFiltros()
        {
            var listaTurnos = (List<TurnoDto>)Session["ListaTurnos"];

            string filtroPaciente = FiltroPaciente.Text.Trim().ToUpper();
            string filtroEstado = FiltroEstado.SelectedValue;

            List<TurnoDto> listaFiltrada = listaTurnos;

            if (!string.IsNullOrEmpty(filtroPaciente))
                listaFiltrada = listaFiltrada.FindAll(x =>
                    x.Paciente.ToUpper().Contains(filtroPaciente)
                );

            if (!string.IsNullOrEmpty(filtroEstado))
                listaFiltrada = listaFiltrada.FindAll(x =>
                    x.Estado.ToString() == filtroEstado
                );

            dgvTurnos.DataSource = listaFiltrada;
            dgvTurnos.DataBind();
        }
    }
}