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
         /* try
            { 
                //guardo el dato del id si esta viajando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString(): "" ;

                // si es diferente de null entonces lo cargo para modificar
                if (id !=null)
               {

                    //busco si ya existe en la db por id
                    EspecialidadNegocio negocio = new EspecialidadNegocio();
                    Especialidad existe = new Especialidad();
                    existe = negocio.BuscarporID(id);

                    //EspecialidadNegocio negocio = new EspecialidadNegocio();
                    //List<Especialidad> lista = negocio.ListarEspecialidades(id);
                    //Especialidad especialidad = lista[0];



                    //si existe lo actualizo, sino lo agrego
                    if (existe != null)
                    {
                        negocio.Actualizar(existe);
                    }
                    else
                    {
                        negocio.Agregar(existe);
                   }


                }
            }
            catch (Exception ex)
            {
               Session.Add("Error", ex);
                throw;
                //redirigir a pantalla de error
            }*/
       
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

                negocio.Agregar(nueva);
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
        
    
