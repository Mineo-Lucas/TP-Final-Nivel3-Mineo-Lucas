﻿using clases;
using Metodos_y_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class VerDetalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            if (seguridad.SesionActiva((User)Session["Logueado"]))
            {
                BtnAgregarFavorito.Visible = true;
                BtnAgregarFavorito.Enabled = true;
            }
            else
            {
                BtnAgregarFavorito.Enabled=false;
                BtnAgregarFavorito.Visible=false;
            }
            Metodos metodos = new Metodos();
            if (!IsPostBack)
            {
                try
                {
                    string Id = Request.QueryString["id"].ToString();
                    Articulo Seleccionado = (metodos.BuscarArticuloPorId(Id))[0];
                    LblNombre.Text = Seleccionado.Nombre;
                    LblDescripcion.Text = Seleccionado.Descripcion;
                    LblCodigo.Text = Seleccionado.Codigo;
                    LblPrecio.Text = Seleccionado.Precio.ToString();
                    LblMarca.Text = Seleccionado.Marca.ToString();
                    LblCategoria.Text = Seleccionado.categoria.ToString();
                    ImgArticulo.ImageUrl = Seleccionado.Imagen;

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");

                }
            }
        }
        protected void BtnAgregarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = Request.QueryString["id"].ToString();
                FavoritosNegocio favo = new FavoritosNegocio();
                Favorito favorito = new Favorito();
                User usuario = (User)Session["Logueado"];
                favorito.IdArticulo = int.Parse(Id);
                favorito.IdUsuario = usuario.Id;
                favo.AgregarArticuloFavoritos(favorito);
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