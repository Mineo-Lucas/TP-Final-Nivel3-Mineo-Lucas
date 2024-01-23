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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Metodos lista = new Metodos();
            try
            {
                ListaArticulos = lista.Listar();
                if (!IsPostBack)
                {
                    DdlCampo.Items.Add("Nombre");
                    DdlCampo.Items.Add("Codigo");
                    DdlCampo.Items.Add("Precio");
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
        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DdlCriterio.Items.Clear();
                if (DdlCampo.Text == "Precio")
                {
                    DdlCriterio.Items.Add("Mayor a");
                    DdlCriterio.Items.Add("Menor a");
                    DdlCriterio.Items.Add("Igual a");
                    RevFiltro.Enabled = true;
                    
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
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    Metodos BuscadoAvanzado = new Metodos();
                    ListaArticulos = BuscadoAvanzado.filtrar(DdlCampo.Text, DdlCriterio.Text, TxtFiltroAvanzado.Text);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }   
            }
        }
    }
}

