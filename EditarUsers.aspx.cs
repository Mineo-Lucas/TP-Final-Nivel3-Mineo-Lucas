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
    public partial class EditarUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string Id = Request.QueryString["Id"] != null ? Id = Request.QueryString["Id"].ToString() : Id = "";
                    if (Id != "")
                    {
                        UserNegocio metodo = new UserNegocio();
                        User Seleccionado = (metodo.BuscarUsuarioPorId(Id))[0];
                        try
                        {
                            TxtId.Text = Id.ToString();


                            if (TxtNombre.Text != null)
                            {
                                TxtNombre.Text = Seleccionado.Nombre;
                            }
                            if (TxtApellido.Text != null)
                            {
                                TxtApellido.Text = Seleccionado.Apellido;
                            }
                            TxtEmail.Text = Seleccionado.Email;
                            TxtPass.Text = Seleccionado.Contraseña;
                            if (TxtImagen.Text != null)
                            {
                                TxtImagen.Text = Seleccionado.Imagen;
                            }
                            CbxAdmin.Checked = Seleccionado.Admin;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            User modificado = new User();
            UserNegocio nego = new UserNegocio();
            try
            {
                modificado.Email = TxtEmail.Text;
                modificado.Contraseña = TxtPass.Text;
                modificado.Nombre = TxtNombre.Text;
                modificado.Apellido = TxtApellido.Text;
                modificado.Id = int.Parse(TxtId.Text);
                modificado.Imagen = TxtImagen.Text;
                modificado.Admin = CbxAdmin.Checked;
                nego.ModificacionTotalUsuario(modificado);
                Response.Redirect("ListadoDeUsuarios.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            UserNegocio neg = new UserNegocio();
            try
            {
                string id = TxtId.Text;
                neg.eliminarUsuario(id);
                Response.Redirect("ListadoDeUsuarios.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}