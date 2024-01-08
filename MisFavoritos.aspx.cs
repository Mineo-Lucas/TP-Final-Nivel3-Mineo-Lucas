
using clases;
using Metodos_y_Conexion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class MisFavoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulosfav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            if (!seguridad.SesionActiva((User)Session["Logueado"]))
            {
                Session.Add("Error", "Necesitas tener permiso de User para poder ingresar");
                Response.Redirect("Error.aspx", false);
            }
            FavoritosNegocio listafavo = new FavoritosNegocio();
            try
            {
                User usuario = (User)Session["Logueado"];
                ListaArticulosfav = listafavo.ListarFavoritos(usuario.Id);
                if (!IsPostBack)
                {
                    DdlCampo.Items.Add("Nombre");
                    DdlCampo.Items.Add("Codigo");
                    DdlCampo.Items.Add("Precio");
                    DdlCriterio.Items.Add("Empieza con");
                    DdlCriterio.Items.Add("Termina con");
                    DdlCriterio.Items.Add("Contiene");
                    RevFiltro.Enabled=false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    DdlCriterio.Items.Clear();
                    if (DdlCampo.Text == "Precio")
                    {
                        DdlCriterio.Items.Add("Mayor a");
                        DdlCriterio.Items.Add("Menor a");
                        DdlCriterio.Items.Add("Igual a");
                        RevFiltro.Enabled= true;
                    }
                    else
                    {
                        DdlCriterio.Items.Add("Empieza con");
                        DdlCriterio.Items.Add("Termina con");
                        DdlCriterio.Items.Add("Contiene");
                        RevFiltro.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Metodos BuscadoAvanzado = new Metodos();
                ListaArticulosfav = BuscadoAvanzado.filtrar(DdlCampo.Text, DdlCriterio.Text, TxtFiltroAvanzado.Text);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}