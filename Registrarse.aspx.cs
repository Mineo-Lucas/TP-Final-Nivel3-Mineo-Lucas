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

            nuevo.Email = TxtEmail.Text;
            nuevo.Contraseña=TxtContraseña.Text;
            negocio.Registrarse(nuevo);
            Response.Redirect("Loguearse.aspx", false);
        }
    }
}