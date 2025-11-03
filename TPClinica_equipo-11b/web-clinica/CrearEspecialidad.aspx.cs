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
    public partial class Especialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
                //txtIdEspecialidad.Enabled = false;
                try
                {
                    //guardo el dato del id si esta viajando en un elemento terciario
                    //string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    string id = Request.QueryString["id"];
                // si es diferente de null entonces lo cargo para modificar

                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(id)) // Si hay ID en la URL, es MODIFICACIÓN
                    {
                        EspecialidadNegocio negocio = new EspecialidadNegocio();
                        Especialidad especialidad = negocio.ListarEspecialidades(id)[0];

                        TextBox1.Text = especialidad.Nombre;
                        TextBox2.Text = especialidad.Descripcion;

                        //  Guardar el ID en el HiddenField
                        hfIdEspecialidad.Value = id;
                    }

                    /*if (id != null)
                    {

                        EspecialidadNegocio negocio = new EspecialidadNegocio();
                        Especialidad especialidad = negocio.ListarEspecialidades(id)[0];

                        TextBox1.Text = especialidad.Nombre;
                        TextBox2.Text = especialidad.Descripcion;


                    }*/
                }
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    throw;
                    //redirigir a pantalla de error
                }
            }

        




        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx", false);
        }



        protected void btnGuardar2_Click(object sender, EventArgs e)
        {
            // alta de una nueva especialidad en la BD
            try
            {
                Especialidad nueva = new Especialidad();
                EspecialidadNegocio negocio = new EspecialidadNegocio();


                nueva.Nombre = TextBox1.Text;
                nueva.Descripcion = TextBox2.Text;

                if (!string.IsNullOrEmpty(hfIdEspecialidad.Value))
                {
                    // ASIGNAR EL ID AL OBJETO ANTES DE ACTUALIZAR
                    nueva.IdEspecialidad = int.Parse(hfIdEspecialidad.Value);

                    negocio.Actualizar(nueva);
                }
                else // Si el HiddenField está vacío, es Agregar
                {

                    negocio.Agregar(nueva);
                }
                
                Response.Redirect("Especialidades.aspx", false);
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
        
    
