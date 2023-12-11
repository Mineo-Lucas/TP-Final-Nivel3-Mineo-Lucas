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
    public partial class ListadoDeUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Seguridad segu= new Seguridad();
            //if (!segu.Admin((User)Session["Logueado"]))
            //{
                //Session.Add("Error", "Necesitas admin para poder entrar");
                //Response.Redirect("Error.aspx");
            //}
            try
            {
                if (!IsPostBack)
                {
                    UserNegocio nego = new UserNegocio();
                    GdvPerfiles.DataSource = nego.ListarUsuarios();
                    GdvPerfiles.DataBind();
                    DdpCampo.Items.Add("Email");
                    DdpCampo.Items.Add("Id");
                    DdpCampo.Items.Add("Nombre");
                }
            }catch(Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }
        protected void DdpCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdpCriterio.Items.Clear();
            if (DdpCampo.Text == "Id")
            {
                DdpCriterio.Items.Add("Menor a");
                DdpCriterio.Items.Add("Mayor a");
                DdpCriterio.Items.Add("Igual a");
            }
            else
            {
                DdpCriterio.Items.Add("Empieza con");
                DdpCriterio.Items.Add("Termina con");
                DdpCriterio.Items.Add("Contiene");
            }
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            UserNegocio nego = new UserNegocio();
            try
            {
                GdvPerfiles.DataSource = nego.UserBuscado(DdpCampo.Text, DdpCriterio.Text, TxtFiltro.Text);
                GdvPerfiles.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}