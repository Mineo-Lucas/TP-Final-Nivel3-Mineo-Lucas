using clases;
using Metodos_y_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CatalogoWeb
{
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcasMetodo marca = new MarcasMetodo();
                CategoriaMetodo cate = new CategoriaMetodo();
                List<Categoria> categoriaslista = cate.listarcategoria();
                DdlCategoria.DataSource = categoriaslista;
                DdlCategoria.DataTextField = "Categoria";
                DdlCategoria.DataValueField = "Id";
                DdlCategoria.DataBind();
                DdlMarca.DataSource = marca.listarMarcas();
                DdlMarca.DataTextField = "marca";
                DdlMarca.DataValueField = "id";
                DdlMarca.DataBind();
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            Metodos metodo = new Metodos();


            try
            {
                nuevo.Nombre = TxtNombre.Text;
                nuevo.Descripcion = TxtDescripcion.Text;
                nuevo.Precio = int.Parse(TxtPrecio.Text);
                nuevo.Codigo = TxtCodigo.Text;
                nuevo.Imagen = TxtImagen.Text;
                nuevo.Marca.id = int.Parse(DdlMarca.SelectedItem.Value);
                nuevo.categoria.Id = int.Parse(DdlCategoria.SelectedItem.Value);
                metodo.AgregarArticulo(nuevo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
            

    }
}
