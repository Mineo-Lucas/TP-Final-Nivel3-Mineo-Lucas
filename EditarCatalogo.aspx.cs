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
    public partial class EditarCatalogo : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            Metodos lista= new Metodos();
            DgvEditarCatalogo.DataSource = lista.Listar();
            DgvEditarCatalogo.DataBind();
            if (!IsPostBack)
            {
                DdlCampo.Items.Add("Nombre");
                DdlCampo.Items.Add("Codigo");
                DdlCampo.Items.Add("Precio");
            }
        }

        protected void DgvEditarCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = DgvEditarCatalogo.SelectedDataKey.Value.ToString();
            Response.Redirect("Modificar-AgregarArticulo.aspx?Id=" + Id, false);
        }

        protected void DgvEditarCatalogo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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
            Metodos BuscadoAvanzado = new Metodos();
            DgvEditarCatalogo.DataSource = BuscadoAvanzado.filtrar(DdlCampo.Text, DdlCriterio.Text, TxtFiltroAvanzado.Text);
            DgvEditarCatalogo.DataBind();
        }
    }
}