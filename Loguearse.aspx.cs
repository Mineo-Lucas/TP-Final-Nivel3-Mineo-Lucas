using Metodos_y_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clases;

namespace CatalogoWeb
{
    public partial class Loguearse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLoguearse_Click(object sender, EventArgs e)
        {
            UserNegocio conectar= new UserNegocio();
            User logueado = new User();
            logueado.Email = TxtEmail.Text;
            logueado.Contraseña= TxtContraseña.Text;
            if (conectar.Loguearse(logueado))
            {
                Session.Add("Logueado", logueado);
                Response.Redirect("home.aspx", false);
            }
        }
    }
}