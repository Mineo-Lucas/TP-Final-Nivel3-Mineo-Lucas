using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clases;

namespace Metodos_y_Conexion
{
    public class UserNegocio
    {
        public void Registrarse(User Nuevo)
        {
            ConexionDB coneccion= new ConexionDB();
            coneccion.setearconsulta("insert into USERS(email, pass) values(@Email, @Contraseña)");
            coneccion.setearparametros("@Email", Nuevo.Email);
            coneccion.setearparametros("@Contraseña", Nuevo.Contraseña);
        }
    }
}
