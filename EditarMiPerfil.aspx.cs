using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clases;
using Metodos_y_Conexion;

namespace CatalogoWeb
{
    public partial class EditarMiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User logueado= (User)Session["Logueado"];
                try
                {
                    TxtNombre.Text = logueado.Nombre;
                    TxtApellido.Text = logueado.Apellido;
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }  
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            UserNegocio nego = new UserNegocio();
            User Modificado = new User();
            try
            {
                string ruta = Server.MapPath("./imagen/");
                User Logueado = (User)Session["Logueado"];
                TxtImagen.PostedFile.SaveAs(ruta + "perfil-" + Logueado.Id+ ".jpg");
                Modificado.Nombre = TxtNombre.Text;
                Modificado.Apellido= TxtApellido.Text;
                Modificado.Imagen = "perfil-" + Logueado.Id + ".jpg";
                Modificado.Id = int.Parse(TxtId.Text);
                nego.ModificarUsuario(Modificado);
                Image img= (Image)Master.FindControl("ImgAvatar");
                img.ImageUrl= "~/imagen/" + Modificado.Imagen;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}