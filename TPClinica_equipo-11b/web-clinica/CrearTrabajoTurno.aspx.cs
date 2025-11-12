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
    public partial class CrearTrabajoTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los Enum de DiaSemana en el CheckBoxList
                // Esto llenará la lista con "Lunes", "Martes", "Miercoles", etc.
                cblDiasLaborales.DataSource = Enum.GetNames(typeof(DiaSemana));
                cblDiasLaborales.DataBind();

                
            }

        }

        protected void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                TurnoTrabajo nuevoTurno = new TurnoTrabajo();
                TurnoTrabajoNegocio negocio = new TurnoTrabajoNegocio();
                nuevoTurno.HoraEntrada = TimeSpan.Parse(txtHoraEntrada.Text);
                nuevoTurno.HoraSalida = TimeSpan.Parse(txtHoraSalida.Text);
                // 2. Obtener Días Seleccionados
                nuevoTurno.DiasLaborales = new List<DiaSemana>();
                foreach (ListItem item in cblDiasLaborales.Items)
                {
                    if (item.Selected)
                    {
                        // Convertir el nombre del día (string) a su valor Enum
                        DiaSemana dia = (DiaSemana)Enum.Parse(typeof(DiaSemana), item.Text);
                        nuevoTurno.DiasLaborales.Add(dia);
                    }
                }

                
                // 3. Guardar/Actualizar
                if (!string.IsNullOrEmpty(hfIdTurnoTrabajo.Value))
                {
                    // Es MODIFICACIÓN
                    nuevoTurno.IdTurnoTrabajo = int.Parse(hfIdTurnoTrabajo.Value);
                    negocio.Actualizar(nuevoTurno);
                }
                else
                {
                    // Es AGREGAR
                    negocio.Agregar(nuevoTurno);
                }

                Response.Redirect("TurnosTrabajo.aspx", false); // Redirigir a una página de listado de turnos
            
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrunosTrabajo.aspx", false);
        }
    }
}