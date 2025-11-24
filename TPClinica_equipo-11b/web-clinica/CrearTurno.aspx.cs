using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class CrearTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica que el usuario se haya loggeado
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            //precarga de formulario para crear turno
            if (!IsPostBack && Session["Turno"] == null)
            {
                EspecialidadNegocio datosEspecialidades = new EspecialidadNegocio();
                List<Especialidad> especialidades = datosEspecialidades.ListarEspecialidades();
                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "IdEspecialidad";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar...", ""));
                ddlEspecialidad.SelectedIndex = 0;
            }
            //precarga de formulario para modificar turno
            if (!IsPostBack && Session["Turno"] != null)
            {
                try
                {
                    // En caso de modificación de un turno se precargan los inputs con valores válidos
                    Turno turno = (Turno)Session["Turno"];

                    PacienteNegocio datosPacientes = new PacienteNegocio();
                    Paciente paciente = datosPacientes.LeerPaciente(turno.IdPaciente);

                    // Datos de paciente
                    List<Paciente> pacientes = datosPacientes.ListarPacientes();
                    txtEmail.Text = paciente.Email;
                    txtApellido.Text = paciente.Apellido;
                    txtNombre.Text = paciente.Nombre;
                    txtDNI.Text = paciente.DNI;
                    txtFechaNacimiento.Text = paciente.FechaNacimiento.ToShortDateString();
                    txtObraSocial.Text = paciente.ObraSocial.Nombre;
                    txtTelefono.Text = paciente.Telefono;

                    //Datos de Medico
                    EspecialidadNegocio datosEspecialidades = new EspecialidadNegocio();
                    List<Especialidad> especialidades = datosEspecialidades.ListarEspecialidades();
                    ddlEspecialidad.DataSource = especialidades;
                    ddlEspecialidad.DataTextField = "Nombre";
                    ddlEspecialidad.DataValueField = "IdEspecialidad";
                    ddlEspecialidad.DataBind();
                    ddlEspecialidad.SelectedValue = turno.IdEspecialidad.ToString();

                    MedicoNegocio datosMedicos = new MedicoNegocio();
                    List<Medico> medicos = datosMedicos.ListarMedicos();
                    ddlMedico.DataSource = medicos;
                    ddlMedico.DataTextField = "Apellido";
                    ddlMedico.DataValueField = "IdMedico";
                    ddlMedico.DataBind();
                    ddlMedico.SelectedValue = turno.IdMedico.ToString();
                    Medico medico = datosMedicos.LeerMedico(turno.IdMedico);
                    txtMatricula.Text = medico.Matricula;

                    //Datos del turno (Fecha, Hora y Observaciones)
                    txtFechaTurno.Text = turno.Fecha.ToString("yyyy-MM-dd");
                    txtObservaciones.Text = turno.Observaciones;

                    //guardan en sesion los datos del turno a modificar
                    Session.Add("IdMedicoSeleccionado", turno.IdMedico);
                    Session.Add("IdPacienteSeleccionado", turno.IdPaciente);
                    Session.Add("IdEspecialidadSeleccionado", turno.IdEspecialidad);
                    Session.Add("FechaSeleccionada", turno.Fecha);

                    //se cargan horarios diponibles
                    List<TimeSpan> horarios = new List<TimeSpan>();
                    for (int hora = 7; hora <= 18; hora++)
                    {
                        horarios.Add(new TimeSpan(hora, 0, 0));
                    }
                    int idMedico = (int)Session["IdMedicoSeleccionado"];
                    DateTime fecha = DateTime.Parse(txtFechaTurno.Text);
                    Session.Add("FechaSeleccionada", fecha);

                    if (fecha.DayOfWeek != DayOfWeek.Sunday && fecha.DayOfWeek != DayOfWeek.Saturday)
                    {
                        TurnoNegocio datosTurnos = new TurnoNegocio();
                        List<TimeSpan> turnosOcupados = datosTurnos.TurnosOcupados(idMedico, fecha);

                        List<TimeSpan> horariosDisponibles = horarios.FindAll(x => !turnosOcupados.Contains(x));

                        horariosDisponibles.Add(turno.Hora);

                        ddlHora.DataSource = horariosDisponibles;
                        ddlHora.DataBind();

                        ddlHora.SelectedValue = turno.Hora.ToString();
                    }
                }
                catch(Exception ex)
                {

                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        // limpiar datos del turno
        protected void btnLimpiarSeleccion_Click(object sender, EventArgs e)
        {
            // se limpian los datos de session antes de salir de la pantalla
            Session.Remove("IdPacienteSeleccionado");
            Session.Remove("IdMedicoSeleccionado");
            Session.Remove("IdEspecialidadSeleccionado");
            Session.Remove("FechaSeleccionada");
            Session.Remove("Turno");
            Response.Redirect("CrearTurno.aspx", false);
        }
        // al seleccionar especialidad se precarga el listado de medicos
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            Session.Add("IdEspecialidadSeleccionado", idEspecialidad);
            MedicoNegocio datosMedicos = new MedicoNegocio();
            List<Medico> medicos = datosMedicos.ListarMedicos(idEspecialidad);

            ddlMedico.DataSource = medicos;
            ddlMedico.DataTextField = "Apellido";
            ddlMedico.DataValueField = "IdMedico";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("Seleccionar...", ""));
            ddlMedico.SelectedIndex = 0;
        }
        // al seleccionar medico se precarga la matricula
        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMedico = int.Parse(ddlMedico.SelectedValue);
            Session.Add("IdMedicoSeleccionado", idMedico);
            MedicoNegocio datosMedicos = new MedicoNegocio();
            Medico medico = datosMedicos.LeerMedico(idMedico);
            txtMatricula.Text = medico.Matricula;
        }
        // al seleccionar una fecha de turno se cargan los horarios disponibles
        protected void txtFechaTurno_TextChanged(object sender, EventArgs e)
        {
            // se crea el listado de horarios con el tipo de dato timespan
            List<TimeSpan> horarios = new List<TimeSpan>();

            // se cargan los datos del medico para obtener dias/horarios laborales y turnos 
            int idMedico = (int)Session["IdMedicoSeleccionado"];
            MedicoNegocio datos = new MedicoNegocio();
            Medico medico = datos.LeerMedico(idMedico);


            for (int hora = Convert.ToInt32(medico.HoraEntrada); hora <= Convert.ToInt32(medico.HoraSalida); hora++)
            {
                horarios.Add(new TimeSpan(hora, 0, 0));
            }

            DateTime fecha = DateTime.Parse(txtFechaTurno.Text);
            Session.Add("FechaSeleccionada", fecha);

            if (fecha.DayOfWeek != DayOfWeek.Sunday && fecha.DayOfWeek != DayOfWeek.Saturday)
            {
                TurnoNegocio datosTurnos = new TurnoNegocio();
                List<TimeSpan> turnosOcupados = datosTurnos.TurnosOcupados(idMedico, fecha);

                List<TimeSpan> horariosDisponibles = horarios.FindAll(x => !turnosOcupados.Contains(x));

                ddlHora.DataSource = horariosDisponibles;
                ddlHora.DataBind();

                ddlHora.Items.Insert(0, new ListItem("Seleccionar hora...", ""));
            }
        }
        // guardar/modificar turno
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                Turno turno = new Turno();
                if (Session["Turno"] != null)
                { 
                    turno.IdTurno = ((Turno)Session["Turno"]).IdTurno;
                }
                turno.IdMedico = (int)Session["IdMedicoSeleccionado"];
                turno.IdPaciente = (int)Session["IdPacienteSeleccionado"];
                turno.IdEspecialidad = (int)Session["IdEspecialidadSeleccionado"];
                turno.Fecha = (DateTime)Session["FechaSeleccionada"];
                turno.Hora = TimeSpan.Parse(ddlHora.Text);
                turno.Observaciones = txtObservaciones.Text;

                TurnoNegocio datos = new TurnoNegocio();

                if (Session["Turno"] == null)
                {
                    datos.CrearTurno(turno);
                }
                else
                {
                    datos.ModificarTurno(turno);
                }

                // se limpian los datos de session antes de salir de la pantalla
                Session.Remove("IdPacienteSeleccionado");
                Session.Remove("IdMedicoSeleccionado");
                Session.Remove("IdEspecialidadSeleccionado");
                Session.Remove("FechaSeleccionada");
                Session.Remove("Turno");
                Response.Redirect("Turnos.aspx", false);
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        // Retornar al listado de turnos removiendo objetos de sesion
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // se limpian los datos de session antes de salir de la pantalla
            Session.Remove("IdPacienteSeleccionado");
            Session.Remove("IdMedicoSeleccionado");
            Session.Remove("IdEspecialidadSeleccionado");
            Session.Remove("FechaSeleccionada");
            Session.Remove("Turno");
            Response.Redirect("Turnos.aspx", false);
        }

        // al ingresar un email se realiza postback y cargan datos de paciente
        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            PacienteNegocio datos = new PacienteNegocio();

            Paciente paciente = datos.LeerPacienteEmail(email);
            if (paciente.Apellido != null)
            {
                txtApellido.Text = paciente.Apellido;
                txtNombre.Text = paciente.Nombre;
                txtDNI.Text = paciente.DNI;
                txtTelefono.Text = paciente.Telefono;
                txtFechaNacimiento.Text = paciente.FechaNacimiento.ToShortDateString();
                txtObraSocial.Text = paciente.ObraSocial.Nombre;
                Session.Add("IdPacienteSeleccionado", paciente.IdPaciente);
            }
            else
            {
                panelToast.CssClass = "toast align-items-center text-bg-danger border-0";
                lblToast.Text = "El email ingresado es inválido.";
                MostrarToast();
            }

        }
        private void MostrarToast()
        {
            string script = @"
        const toastEl = document.getElementById('" + panelToast.ClientID + @"');
        const toast = new bootstrap.Toast(toastEl);
        toast.show();";

            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "mostrarToast",
                script,
                true
            );
        }
    }
}