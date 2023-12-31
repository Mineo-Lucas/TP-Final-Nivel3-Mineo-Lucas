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
    public partial class EditarMiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            if (!seguridad.SesionActiva((User)Session["Logueado"]))
            {
                Session.Add("Error", "Necesitas tener permiso de admin para poder ingresar");
                Response.Redirect("Error.aspx", false);
            }
            if (!IsPostBack)
            {
                User logueado = (User)Session["Logueado"];
                try
                {
                    if (logueado.Nombre != null)
                    {
                        TxtNombre.Text = logueado.Nombre;
                    }
                    if (logueado.Apellido != null)
                    {
                        TxtApellido.Text = logueado.Apellido;
                    }
                    TxtId.Text = logueado.Id.ToString();
                    TxtId.Enabled = false;
                    TxtId.Visible = false;
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            UserNegocio nego = new UserNegocio();
            try
            {
                string ruta = Server.MapPath("./imagen/");
                User Logueado = (User)Session["Logueado"];
                TxtImagen.PostedFile.SaveAs(ruta + "perfil-" + Logueado.Id + ".jpg");
                Logueado.Nombre = TxtNombre.Text;
                Logueado.Apellido = TxtApellido.Text;
                Logueado.Imagen = "perfil-" + Logueado.Id + ".jpg";
                Logueado.Id = int.Parse(TxtId.Text);
                nego.ModificarUsuario(Logueado);
                Image img = (Image)Master.FindControl("ImgAvatar");
                img.ImageUrl = "~/imagen/" + Logueado.Imagen;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }
    }
}