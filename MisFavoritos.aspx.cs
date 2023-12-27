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
            FavoritosNegocio listafavo = new FavoritosNegocio();
            User usuario = (User)Session["Logueado"];
            ListaArticulosfav = listafavo.ListarFavoritos(usuario.Id);
        }

        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}