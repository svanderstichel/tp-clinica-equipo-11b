using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class ObrasSociales : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            //Configuracion si estamos modificando
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                //Puedo traerme la lista desde sesion o desde bd
                //obtengo el id de la url
                //int id = int.Parse(Request.QueryString["id"].ToString());
                //List<ObraSocial> temporal = (List<ObraSocial>)Session["listaOS"];
                //ObraSocial seleccionada =  temporal.Find(x => x.IdObraSocial == id);

                ObraSocialNegocio negocio = new ObraSocialNegocio();
                List<ObraSocial> lista = negocio.ListarObrasSociales(Request.QueryString["id"].ToString());
                ObraSocial seleccionada = lista[0]; //porque la lista solo tiene un registro

                //precargo todos los campos
                txtNombre.Text = seleccionada.Nombre;
                txtDescripcion.Text = seleccionada.Descripcion;

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocial nueva = new ObraSocial();
                ObraSocialNegocio negocio = new ObraSocialNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Descripcion = txtDescripcion.Text;

                //me traigo de la sesion la lista de os
                List<ObraSocial> temporal = (List<ObraSocial>)Session["listaOS"];
                temporal.Add(nueva);

                //si vino un id estoy modificando
                if (Request.QueryString["id"] != null)
                {
                    nueva.IdObraSocial = int.Parse(Request.QueryString["id"].ToString());
                    negocio.Actualizar(nueva);
                }
                else
                {
                    negocio.Agregar(nueva);
                }
                //Actualizp la lista en sesión
                Session["listaOS"] = negocio.ListarObrasSociales();
                Response.Redirect("ObrasSociales.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ObrasSociales.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    ObraSocialNegocio negocio = new ObraSocialNegocio(); 

                    //recupero el id de la sesion
                    int id = int.Parse(Request.QueryString["id"].ToString());

                    negocio.EliminarLogico(id);

                    //actualizo la sesion
                    Session["listaOS"] = negocio.ListarObrasSociales();
                    Response.Redirect("ObrasSociales.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}