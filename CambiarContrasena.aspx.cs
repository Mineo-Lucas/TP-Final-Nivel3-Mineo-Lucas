using clases;
using Metodos_y_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            if (!seguridad.SesionActiva((User)Session["Logueado"]))
            {
                Session.Add("Error", "Necesitas tener permiso de admin para poder ingresar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void BtnCambiarContraseña_Click(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            User logueado = (User)Session["Logueado"];
            UserNegocio nego = new UserNegocio();
            try
            {
                if (seguridad.ValidarVacioNull(TxtContraseñaactual.Text) && seguridad.ValidarVacioNull(TxtNuevaContraseña.Text) && seguridad.ValidarVacioNull(TxtNuevaContraseña2.Text))
                {
                    if(seguridad.Contraseña(TxtContraseñaactual.Text, logueado.Id))
                    {
                        if(TxtNuevaContraseña.Text == TxtNuevaContraseña2.Text)
                        {
                            nego.CambiarContraseña(logueado.Id,TxtNuevaContraseña.Text);
                            Response.Redirect("Default.aspx", false);
                        }
                        else
                        {
                            Session.Add("Error", "Su nueva contraseña no coincide...");
                            Response.Redirect("Error.aspx", false);
                        }
                    }
                    else
                    {
                        Session.Add("Error", "Su contraseña actual no es la misma...");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Session.Add("Error", "Completa todos los campos...");
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