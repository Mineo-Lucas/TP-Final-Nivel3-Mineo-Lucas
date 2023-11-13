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
        }

        protected void DgvEditarCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = DgvEditarCatalogo.SelectedDataKey.Value.ToString();
            Response.Redirect("Modificar-AgregarArticulo.aspx?Id=" + Id, false);
        }

        protected void DgvEditarCatalogo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}