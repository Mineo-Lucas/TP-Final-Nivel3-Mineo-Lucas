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
            Seguridad seguridad = new Seguridad();
            Metodos lista = new Metodos();
            if (seguridad.SesionActiva((User)Session["Logueado"]))
            {
                if (seguridad.Admin((User)Session["Logueado"]))
                {
                    try
                    {
                        DgvEditarCatalogo.DataSource = lista.Listar();
                        DgvEditarCatalogo.DataBind();
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
                else
                {
                    Session.Add("Error", "Necesitas tener permiso de admin para poder ingresar");
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                Session.Add("Error", "Necesitas tener permiso de admin para poder ingresar");
                Response.Redirect("Error.aspx", false);
            }
        }

    protected void DgvEditarCatalogo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string Id = DgvEditarCatalogo.SelectedDataKey.Value.ToString();
            Response.Redirect("Modificar-AgregarArticulo.aspx?Id=" + Id, false);
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
        Metodos BuscadoAvanzado = new Metodos();
        try
        {
            DgvEditarCatalogo.DataSource = BuscadoAvanzado.filtrar(DdlCampo.Text, DdlCriterio.Text, TxtFiltroAvanzado.Text);
            DgvEditarCatalogo.DataBind();
        }
        catch (Exception ex)
        {
            Session.Add("Error", ex.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }

    protected void BtnAgregarArticulo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Modificar-AgregarArticulo.aspx", false);
        }
        catch (Exception ex)
        {
            Session.Add("Error", ex.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }

    protected void DgvEditarCatalogo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DgvEditarCatalogo.PageIndex = e.NewPageIndex;
        DgvEditarCatalogo.DataBind();
    }
}
}