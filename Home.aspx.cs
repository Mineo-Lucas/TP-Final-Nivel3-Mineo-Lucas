using clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Metodos_y_Conexion;

namespace CatalogoWeb
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Metodos lista = new Metodos();
            ListaArticulos = lista.Listar();
            if (!IsPostBack)
            {
                DdlCampo.Items.Add("Nombre");
                DdlCampo.Items.Add("Codigo");
                DdlCampo.Items.Add("Precio");
            }

        }

        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCriterio.Items.Clear();
            if (DdlCampo.Text == "Precio")
            {
                DdlCriterio.Items.Add("Mayor a");
                DdlCriterio.Items.Add("Menor a");
                DdlCriterio.Items.Add("Igual a");
            }
            else
            {
                DdlCriterio.Items.Add("Empieza con");
                DdlCriterio.Items.Add("Termina con");
                DdlCriterio.Items.Add("Contiene");
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            {
                Metodos BuscadoAvanzado = new Metodos();
                ListaArticulos = BuscadoAvanzado.filtrar(DdlCampo.Text, DdlCriterio.Text, TxtFiltroAvanzado.Text);
            }
        }

        protected void BtnFavoritos_Click(object sender, EventArgs e)
        {
            FavoritosNegocio nego =new FavoritosNegocio();
            Favorito favo = new Favorito();
            try
            {
                User usuario = (User)Session["Logueado"];
                favo.IdUsuario = usuario.Id;
                //favo.IdArticulo = int.Parse(.Text);
                nego.AgregarArticuloFavoritos(favo);
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}

