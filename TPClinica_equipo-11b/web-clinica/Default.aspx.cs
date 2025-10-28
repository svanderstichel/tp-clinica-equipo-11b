using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_clinica
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}