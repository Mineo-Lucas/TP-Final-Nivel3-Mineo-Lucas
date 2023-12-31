using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using clases;
using static System.Net.Mime.MediaTypeNames;

namespace Metodos_y_Conexion
{
    public class UserNegocio
    {
        public List<User> ListarUsuarios()
        {
            ConexionDB conec = new ConexionDB();
            List<User> usuarios = new List<User>();

            try
            {
                conec.setearconsulta("select Id,email, pass, nombre, apellido, urlImagenPerfil, administrador from USERS");
                conec.ejecutarlectura();
                while (conec.Lector.Read())
                {
                    User usuario = new User();
                    if (conec.Lector["nombre"].ToString() != "")
                    {
                        usuario.Nombre = (string)conec.Lector["nombre"];
                    }
                    if (conec.Lector["apellido"].ToString() != "")
                    {
                        usuario.Apellido = (string)conec.Lector["apellido"];
                    }
                    usuario.Email = (string)conec.Lector["email"];
                    usuario.Id = int.Parse(conec.Lector["Id"].ToString());
                    if (conec.Lector["urlImagenPerfil"].ToString() != "")
                    {
                        usuario.Imagen = (string)conec.Lector["urlImagenPerfil"];
                    }
                    usuario.Admin = (bool)conec.Lector["administrador"];
                    usuario.Contraseña = (string)conec.Lector["pass"];
                    usuarios.Add(usuario);
                }
                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conec.cerrarconexion();
            }
        }
        public List<User> UserBuscado(string campo, string criterio, string text)
        {
            ConexionDB con = new ConexionDB();
            List<User> usuariosfiltrados = new List<User>();
            try
            {
                string consu = ("select Id,email, pass, nombre, apellido, urlImagenPerfil, administrador from USERS where ");
                switch (campo)
                {
                    case "Id":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consu += "Id >" + text;
                                break;
                            case "Menor a":
                                consu += "Id <" + text;
                                break;
                            default:
                                consu += "Id =" + text;
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empienza con":
                                consu += "nombre like '" + text + "%'";
                                break;
                            case "Termina con":
                                consu += "nombre like '%" + text + "'";
                                break;
                            case "Contiene":
                                consu += "nombre like '%" + text + "%'";
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Empieza con":
                                consu += "email like '" + text + "%'";
                                break;
                            case "Termina con":
                                consu += "email like '%" + text + "'";
                                break;
                            case "Contiene":
                                consu += "email like '%" + text + "%'";
                                break;
                        }
                        break;
                }
                con.setearconsulta(consu);
                con.ejecutarlectura();
                while (con.Lector.Read())
                {

                    User userbuscado = new User();
                    if (userbuscado.Nombre != null)
                    {
                        userbuscado.Nombre = (string)con.Lector["nombre"];
                    }
                    if (userbuscado.Apellido != null)
                    {
                        userbuscado.Apellido = (string)con.Lector["apellido"];
                    }
                    userbuscado.Email = (string)con.Lector["email"];
                    userbuscado.Id = int.Parse(con.Lector["Id"].ToString());
                    if (userbuscado.Imagen != null)
                    {
                        userbuscado.Imagen = (string)con.Lector["urlImagenPerfil"];
                    }
                    userbuscado.Admin = (bool)con.Lector["administrador"];
                    userbuscado.Contraseña = (string)con.Lector["pass"];
                    usuariosfiltrados.Add(userbuscado);

                }
                return usuariosfiltrados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.cerrarconexion();
            }
        }
        public List<User> BuscarUsuarioPorId(string Id)
        {
            List<User> lista = new List<User>();
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.setearconsulta("select Id,email, pass, nombre, apellido, urlImagenPerfil, administrador from USERS where Id=@Id");
                conexion.setearparametros("@Id", Id);
                conexion.ejecutarlectura();

                while (conexion.Lector.Read())
                {
                    User Userbusc = new User();
                    Userbusc.Email = (string)conexion.Lector["email"];
                    Userbusc.Contraseña = (string)conexion.Lector["pass"];
                    if (conexion.Lector["urlImagenPerfil"].ToString() != "")
                    {
                        Userbusc.Imagen = (string)conexion.Lector["urlImagenPerfil"];
                    }
                    if (conexion.Lector["nombre"].ToString() != "")
                    {
                        Userbusc.Nombre = (string)conexion.Lector["nombre"];
                    }
                    if (conexion.Lector["apellido"].ToString() != "")
                    {
                        Userbusc.Apellido = (string)conexion.Lector["apellido"];
                    }
                    Userbusc.Id = (int)conexion.Lector["Id"];
                    Userbusc.Admin = (bool)conexion.Lector["Administrador"];
                    lista.Add(Userbusc);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarconexion();
            }

        }
        public void Registrarse(User Nuevo)
        {
            ConexionDB coneccion = new ConexionDB();
            try
            {
                coneccion.setearconsulta("insert into USERS(email, pass) values(@Email, @Contraseña)");
                coneccion.setearparametros("@Email", Nuevo.Email);
                coneccion.setearparametros("@Contraseña", Nuevo.Contraseña);
                coneccion.ejecutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                coneccion.cerrarconexion();
            }
        }
        public bool Loguearse(User logueado)
        {
            ConexionDB conec = new ConexionDB();
            try
            {
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
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conec.cerrarconexion();
            }

        }
        public void ModificarUsuario(User modificado)
        {
            ConexionDB conectar = new ConexionDB();
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
            finally
            {
                conectar.cerrarconexion();
            }
        }
        public void ModificacionTotalUsuario(User modificado)
        {
            ConexionDB conectar = new ConexionDB();
            try
            {
                conectar.setearconsulta("update USERS set email=@email, pass=@pass, nombre = @Nombre, apellido = @Apellido, urlImagenPerfil = @Imagen, administrador=@admin where Id = @Id");
                conectar.setearparametros("@email", modificado.Email);
                conectar.setearparametros("@pass", modificado.Contraseña);
                conectar.setearparametros("@Nombre", modificado.Nombre);
                conectar.setearparametros("@Apellido", modificado.Apellido);
                conectar.setearparametros("@Imagen", modificado.Imagen);
                conectar.setearparametros("@admin", modificado.Admin);
                conectar.setearparametros("@Id", modificado.Id);
                conectar.ejecutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conectar.cerrarconexion();
            }
        }
        public void eliminarUsuario(string eliminado)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.setearconsulta("delete USERS where Id = @Id");
                con.setearparametros("@Id", eliminado);
                con.ejecutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.cerrarconexion(); }

        }
        public bool email(string email)
        {
            ConexionDB conec = new ConexionDB();
            try
            {
                conec.setearconsulta("select email from USERS where email= @Email");
                conec.setearparametros("@Email", email);
                conec.ejecutarlectura();
                if (conec.Lector.Read())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
