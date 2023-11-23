using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clases;
using static System.Net.Mime.MediaTypeNames;

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
        public bool Loguearse(User logueado)
        {
            ConexionDB conec = new ConexionDB();
            conec.setearconsulta("select Id,email,pass,nombre,apellido,urlImagenPerfil,administrador from USERS where email= @Email and pass=@Contraseña");
            conec.setearparametros("@Email", logueado.Email);
            conec.setearparametros("@Contraseña", logueado.Contraseña);
            conec.ejecutarlectura();
            while (conec.Lector.Read())
            {
                logueado.Nombre = conec.Lector["nombre"].ToString();
                logueado.Apellido = conec.Lector["apellido"].ToString();
                logueado.Imagen = conec.Lector["urlImagenPerfil"].ToString();
                logueado.Admin = (bool)conec.Lector["administrador"];
                logueado.Id = int.Parse(conec.Lector["Id"].ToString());
                return true;
            }return false;
            
        }
        public void ModificarUsuario(User modificado)
        {
            ConexionDB conectar= new ConexionDB();
            try
            {
                conectar.setearconsulta("update USERS set nombre = @Nombre, apellido = @Apellido, urlImagenPerfil = @Imagen where Id = @Id");
                conectar.setearparametros("@Nombre", modificado.Nombre);
                conectar.setearparametros("@Apellido", modificado.Apellido);
                conectar.setearparametros("@Imagen", modificado.Imagen);
                conectar.setearparametros("@Id", modificado.Id);
                conectar.ejecutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
