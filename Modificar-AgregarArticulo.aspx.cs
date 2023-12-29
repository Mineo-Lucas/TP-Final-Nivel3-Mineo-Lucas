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
            Seguridad seguridad = new Seguridad();
            if (!seguridad.SesionActiva((User)Session["Logueado"]))
            {
                Session.Add("Error", "Necesitas tener permiso de admin para poder ingresar");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                if (!seguridad.Admin((User)Session["Logueado"]))
                {
                    Session.Add("Error", "Necesitas tener permiso de admin para poder ingresar");
                    Response.Redirect("Error.aspx", false);
                }
            }
            TxtId.Enabled = false;
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

                string Id = Request.QueryString["Id"] != null ? Id = Request.QueryString["Id"].ToString() : Id = "";
                if (Id!="")
                {
                    Metodos metodo= new Metodos();
                    Articulo Seleccionado = (metodo.BuscarArticuloPorId(Id))[0];
                    try
                    {
                        TxtId.Text=Id.ToString();
                        TxtNombre.Text = Seleccionado.Nombre;
                        TxtDescripcion.Text = Seleccionado.Descripcion;
                        TxtPrecio.Text = Seleccionado.Precio.ToString();
                        TxtCodigo.Text = Seleccionado.Codigo;
                        TxtImagen.Text = Seleccionado.Imagen;
                        DdlCategoria.SelectedValue = Seleccionado.categoria.Id.ToString();
                        DdlMarca.SelectedValue = Seleccionado.Marca.id.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    BtnAceptar.Text = "Modificar";
                }
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
                nuevo.Precio = decimal.Parse(TxtPrecio.Text);
                nuevo.Codigo = TxtCodigo.Text;
                nuevo.Imagen = TxtImagen.Text;
                nuevo.Marca = new Marcas();
                nuevo.Marca.id=int.Parse(DdlCategoria.SelectedItem.Value);
                nuevo.categoria = new Categoria();
                nuevo.categoria.Id = int.Parse(DdlCategoria.SelectedItem.Value);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(TxtId.Text);
                    metodo.Modificar(nuevo);
                }
                else
                {
                    metodo.AgregarArticulo(nuevo);
                }
                    Response.Redirect("EditarCatalogo.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            Metodos eliminar = new Metodos();
            try
            {
                string id = Request.QueryString["Id"].ToString();
                eliminar.eliminar(id);
                Response.Redirect("EditarCatalogo.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
               
            
        }
    }
}
