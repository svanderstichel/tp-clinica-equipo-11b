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
            if (!IsPostBack && Session["Turno"] == null)
            {
                PacienteNegocio datosPacientes = new PacienteNegocio();
                List<Paciente> pacientes = datosPacientes.ListarPacientes();
                ddlApellido.DataSource = pacientes;
                ddlApellido.DataTextField = "Apellido";
                ddlApellido.DataBind();
                ddlApellido.Items.Insert(0, new ListItem("Seleccionar...", ""));
                ddlApellido.SelectedIndex = 0;

                EspecialidadNegocio datosEspecialidades = new EspecialidadNegocio();
                List<Especialidad> especialidades = datosEspecialidades.ListarEspecialidades();
                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "IdEspecialidad";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar...", ""));
                ddlEspecialidad.SelectedIndex = 0;
            }
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
                    ddlApellido.DataSource = pacientes;
                    ddlApellido.DataTextField = "Apellido";
                    ddlApellido.DataBind();
                    ddlApellido.SelectedValue = paciente.Apellido;

                    ddlNombre.DataSource = pacientes;
                    ddlNombre.DataTextField = "Nombre";
                    ddlNombre.DataBind();
                    ddlNombre.SelectedValue = paciente.Nombre;

                    ddlEmail.DataSource = pacientes;
                    ddlEmail.DataTextField = "Email";
                    ddlEmail.DataBind();
                    ddlEmail.SelectedValue = paciente.Email;

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

                    Session.Add("IdMedicoSeleccionado", turno.IdMedico);
                    Session.Add("IdPacienteSeleccionado", turno.IdPaciente);
                    Session.Add("IdEspecialidadSeleccionado", turno.IdEspecialidad);
                    Session.Add("FechaSeleccionada", turno.Fecha);

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

        protected void ddlApellido_SelectedIndexChanged(object sender, EventArgs e)
        {
                PacienteNegocio datosPacientes = new PacienteNegocio();
                List<Paciente> pacientes = datosPacientes.ListarPacientes();
                string apellido = Convert.ToString(ddlApellido.SelectedItem.Text);
                ddlNombre.DataSource = pacientes.FindAll(x => x.Apellido == apellido);  
                ddlNombre.DataTextField = "Nombre";
                ddlNombre.DataValueField = "IdPaciente";
                ddlNombre.DataBind();
                ddlNombre.Items.Insert(0, new ListItem("Seleccionar...", ""));
                ddlNombre.SelectedIndex = 0;

        }

        protected void ddlNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
                PacienteNegocio datosPacientes = new PacienteNegocio();
                List<Paciente> pacientes = datosPacientes.ListarPacientes();
                string nombre = Convert.ToString(ddlNombre.SelectedItem.Text);
                ddlEmail.DataSource = pacientes.FindAll(x => x.Nombre == nombre);
                ddlEmail.DataTextField = "Email";
                ddlEmail.DataValueField = "IdPaciente";
                ddlEmail.DataBind();
                ddlEmail.Items.Insert(0, new ListItem("Seleccionar...", ""));
                ddlEmail.SelectedIndex = 0;
        }
        protected void ddlEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdPaciente = int.Parse(ddlEmail.SelectedValue);
            PacienteNegocio datosPacientes = new PacienteNegocio();
            Paciente paciente = datosPacientes.LeerPaciente(IdPaciente);
            Session.Add("IdPacienteSeleccionado", IdPaciente);
            txtDNI.Text = paciente.DNI;
            txtFechaNacimiento.Text = paciente.FechaNacimiento.ToShortDateString();
            txtObraSocial.Text = paciente.ObraSocial.Nombre;
            txtTelefono.Text = paciente.Telefono;
        }
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

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMedico = int.Parse(ddlMedico.SelectedValue);
            Session.Add("IdMedicoSeleccionado", idMedico);
            MedicoNegocio datosMedicos = new MedicoNegocio();
            Medico medico = datosMedicos.LeerMedico(idMedico);
            txtMatricula.Text = medico.Matricula;
        }

        protected void txtFechaTurno_TextChanged(object sender, EventArgs e)
        {
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

                ddlHora.DataSource = horariosDisponibles;
                ddlHora.DataBind();

                ddlHora.Items.Insert(0, new ListItem("Seleccionar hora...", ""));
            }
        }

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
    }
}