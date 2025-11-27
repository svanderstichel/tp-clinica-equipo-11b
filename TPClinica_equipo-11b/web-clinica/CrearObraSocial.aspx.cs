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
    //  public partial class ObrasSociales : System.Web.UI.Page
    public partial class CrearObraSocial : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "No se ha logeado correctamente, no tiene permiso para ingresar.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            //ConfirmaEliminacion = false;
            // Configuracion si estamos modificando

            /*Si del objeto Request estoy trayendo el id*/
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                ObraSocialNegocio negocio = new ObraSocialNegocio();
                ObraSocial seleccionada = (negocio.ListarObrasSociales(id))[0]; //porque la lista solo tiene un registro

                //Precargo todos los campos
                txtNombre.Text = seleccionada.Nombre;
                txtDescripcion.Text = seleccionada.Descripcion;
                txtCobertura.Text = seleccionada.Cobertura;


                if (seleccionada.Estado)
                {
                    btnInactivar.Visible = true;   // Está activa puedo desactivarla
                    btnActivar.Visible = false;
                }
                else
                {
                    btnActivar.Visible = true;     // Está inactiva puedo activarla
                    btnInactivar.Visible = false;
                }
            }
            else
            {
                //si es alta
                btnActivar.Visible = false;
                btnInactivar.Visible = false;
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
                nueva.Cobertura = txtCobertura.Text;

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

                Response.Redirect("ObrasSociales.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ObrasSociales.aspx", false);
        }

        //protected void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    ConfirmaEliminacion = true;
        //}

        //protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkConfirmarEliminacion.Checked)
        //        {
        //            ObraSocialNegocio negocio = new ObraSocialNegocio();

        //            //recupero el id de la sesion
        //            int id = int.Parse(Request.QueryString["id"].ToString());

        //            negocio.EliminarLogico(id);

        //            //actualizo la sesion
        //        //    Session["listaOS"] = negocio.ListarObrasSociales();
        //            Response.Redirect("ObrasSociales.aspx", false);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Session.Add("error", ex);
        //    }
        //}

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocialNegocio negocio = new ObraSocialNegocio();
                int id = int.Parse(Request.QueryString["id"]);
                negocio.EliminarLogico(id, false);
                Response.Redirect("ObrasSociales.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocialNegocio negocio = new ObraSocialNegocio();
                int id = int.Parse(Request.QueryString["id"]);
                negocio.EliminarLogico(id, true);
                Response.Redirect("ObrasSociales.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}