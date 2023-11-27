using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Metodos_y_Conexion;

namespace CatalogoWeb
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            if (!(Page is Home || Page is Registrarse || Page is Loguearse || Page is VerDetalles))
            {
                if (!(seguridad.SesionActiva(Session["Logueado"])))
                {
                    Response.Redirect("Loguearse.aspx", false);
                }
            }
        }

        protected void BtnLoguearse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loguearse.aspx", false);
        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx", false);
        }
    }
}