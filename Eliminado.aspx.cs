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
    public partial class Eliminado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            if (!seguridad.SesionActiva((User)Session["Logueado"]))
            {
                Session.Add("Error", "Necesitas tener permiso de User para poder ingresar");
                Response.Redirect("Error.aspx", false);
            }
            Metodos metodos = new Metodos();
            if (!IsPostBack)
            {
                try
                {
                    string Id = Request.QueryString["id"].ToString();
                    Articulo Seleccionado = (metodos.BuscarArticuloPorId(Id))[0];
                    LblDescripcion.Text = Seleccionado.Descripcion;
                    LblCodigo.Text = Seleccionado.Codigo;
                    LblPrecio.Text = Seleccionado.Precio.ToString();
                    LblMarca.Text = Seleccionado.Marca.ToString();
                    LblCategoria.Text = Seleccionado.categoria.ToString();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void BtnEliminarFavorito_Click(object sender, EventArgs e)
        {
            Metodos eliminar = new Metodos();
            try
            {
                string id = Request.QueryString["Id"].ToString();
                eliminar.eliminar(id);
                Response.Redirect("MisFavoritos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}