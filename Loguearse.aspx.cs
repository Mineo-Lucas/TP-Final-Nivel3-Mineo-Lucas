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
            UserNegocio conectar = new UserNegocio();
            User logueado = new User();
            Seguridad seguridad = new Seguridad();
            try
            {
                if (seguridad.ValidarVacioNull(TxtEmail.Text) && seguridad.ValidarVacioNull(TxtContraseña.Text))
                {
                    logueado.Email = TxtEmail.Text;
                    logueado.Contraseña = TxtContraseña.Text;
                    if (conectar.Loguearse(logueado))
                    {
                        Session.Add("Logueado", logueado);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        Session.Add("Error", "Usuario o contraseña incorrectos");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Session.Add("Error", "Debes completar todos los campos");
                    Response.Redirect("Error.aspx", false);
                }    
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}