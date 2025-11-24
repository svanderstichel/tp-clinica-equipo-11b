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
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            ConfirmarEliminacion =false;
            
            //guardo el dato del id 
            string id = Request.QueryString["id"];

            if (!IsPostBack)
            {
            try
            {
                    if (!string.IsNullOrEmpty(id)) // Si hay ID en la URL, es MODIFICACIÓN
                    {
                        MedicoNegocio negocio = new MedicoNegocio();
                        Medico medico = negocio.ListarMedicos(id)[0];
                        
                        textBox1.Text = medico.Nombre;
                        textBox2.Text = medico.Apellido;
                        textBox6.Text = medico.Matricula;
                        textBox3.Text = medico.Email;
                        textBox4.Text = medico.Telefono;
                        //  Guardar el ID en el HiddenField
                        hfIdMedico.Value = id;
                    }

                
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
                //redirigir a pantalla de error
            }

            }




        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx", false);
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
                
                if (!string.IsNullOrEmpty(hfIdMedico.Value))
                {
                    // Es MODIFICACIÓN
                    nueva.IdMedico = int.Parse(hfIdMedico.Value); // Asignar el ID recuperado
                    negocio.Actualizar (nueva); //  Llamar al método de Modificación (Debe existir)
                }
                else
                {
                    negocio.Agregar(nueva);
                }
                
                Response.Redirect("Medicos.aspx", false);
            }
            catch (Exception ex)
            {
                
                Session.Add("Error", ex);
                throw;
                //redirigir a pantalla de error
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio negocio = new MedicoNegocio();
                Medico nueva = new Medico();
                nueva.IdMedico = int.Parse(hfIdMedico.Value);
                negocio.EliminarMedico(nueva.IdMedico);
                Response.Redirect("Medicos.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
                //redirigir a pantalla de error
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio negocio = new MedicoNegocio();
                Medico nueva = new Medico();
                nueva.IdMedico = int.Parse(hfIdMedico.Value);
                negocio.EliminarLogico(nueva.IdMedico);
                Response.Redirect("Medicos.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
                //redirigir a pantalla de error
            }

        }

       

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio negocio = new MedicoNegocio();
                Medico nueva = new Medico();
                nueva.IdMedico = int.Parse(hfIdMedico.Value);
                negocio.EliminarLogico(nueva.IdMedico, true);
                Response.Redirect("Medicos.aspx");
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
