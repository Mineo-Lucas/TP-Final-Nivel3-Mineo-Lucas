using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clases;
using Metodos_y_Conexion;
using static System.Net.WebRequestMethods;

namespace CatalogoWeb
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            BtnSalir.Enabled = false;
            BtnSalir.Visible = false;
            BtnEditarCatalogo.Visible = false;
            BtnMisFavoritos.Visible = false;
            ImgAvatar.Visible = false;
            BtnMiPerfil.Visible = false;
            if (!(Page is Default|| Page is Registrarse || Page is Loguearse || Page is VerDetalles || Page is Error || Page is VerDetalles))
            {
                if (!seguridad.SesionActiva((User)Session["Logueado"]))
                {
                    Response.Redirect("Loguearse.aspx", false);
                }
            }
            if (seguridad.SesionActiva((User)Session["Logueado"]))
            {
                BtnLoguearse.Enabled = false;
                BtnLoguearse.Visible = false;
                BtnRegistrarse.Enabled = false;
                BtnRegistrarse.Visible = false;
                BtnMiPerfil.Visible = true;
                BtnMisFavoritos.Visible=true;
                BtnSalir.Enabled = true;
                BtnSalir.Visible = true;
                User Logueado = (User)Session["Logueado"];
                LblEmailUsuario.Text = Logueado.Email;
                if (Logueado.Imagen != "")
                {
                    ImgAvatar.Visible = true;
                    ImgAvatar.ImageUrl = "~/Imagen/" + Logueado.Imagen + "?v=" + DateTime.Now.Ticks.ToString();
                }
                else
                {
                    ImgAvatar.Visible = true;
                    ImgAvatar.ImageUrl = "https://cdn.playbuzz.com/cdn/913253cd-5a02-4bf2-83e1-18ff2cc7340f/c56157d5-5d8e-4826-89f9-361412275c35.jpg";
                }
                if (seguridad.Admin((User)Session["Logueado"]))
                {
                    BtnEditarCatalogo.Visible = true;
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

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}