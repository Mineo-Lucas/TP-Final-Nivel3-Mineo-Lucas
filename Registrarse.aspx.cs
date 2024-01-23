﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Metodos_y_Conexion;
using clases;

namespace CatalogoWeb
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            User nuevo = new User();
            Seguridad segu = new Seguridad();
            try
            {
                if (segu.ValidarVacioNull(TxtEmail.Text) && segu.ValidarVacioNull(TxtContraseña.Text))
                {
                    if (negocio.Email(TxtEmail.Text))
                    {
                        nuevo.Email=TxtEmail.Text;
                        nuevo.Contraseña = TxtContraseña.Text;
                        negocio.Registrarse(nuevo);
                        Response.Redirect("Loguearse.aspx", false);
                    }
                    else
                    {
                        Session.Add("Error", "Este email ya esta registrado");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Session.Add("Error", "Debes completar todos los campos");
                    Response.Redirect("Error.aspx", false);
                }     
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}