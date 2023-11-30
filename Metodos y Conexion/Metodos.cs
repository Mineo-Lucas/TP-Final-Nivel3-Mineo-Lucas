using clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_y_Conexion
{
    public class Metodos
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.setearconsulta("select Codigo,Nombre,a.Descripcion,c.Descripcion Categoria,m.Descripcion Marca,ImagenUrl,Precio,a.IdCategoria,a.IdMarca,a.Id from ARTICULOS a, CATEGORIAS c, MARCAS m where c.Id=IdCategoria and m.Id=IdMarca");
                conexion.ejecutarlectura();

                while (conexion.Lector.Read())
                {
                    Articulo arti = new Articulo();
                    arti.Codigo = (string)conexion.Lector["Codigo"];
                    arti.Nombre = (string)conexion.Lector["Nombre"];
                    if (conexion.Lector != null)
                    {
                        arti.Imagen = (string)conexion.Lector["ImagenUrl"];
                    }
                    arti.Descripcion = (string)conexion.Lector["Descripcion"];
                    arti.Precio= (decimal)conexion.Lector["Precio"];
                    arti.Marca = new Marcas();
                    arti.Marca.marca = (string)conexion.Lector["Marca"];
                    arti.Marca.id = (int)conexion.Lector["IdMarca"];
                    arti.categoria = new Categoria();
                    arti.categoria.categoria = (string)conexion.Lector["categoria"];
                    arti.categoria.Id = (int)conexion.Lector["IdCategoria"];
                    arti.Id = (int)conexion.Lector["Id"];
                    lista.Add(arti);
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
        public List<Articulo> BuscarArticuloPorId(string Id)
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.setearconsulta("select Codigo,Nombre,a.Descripcion,c.Descripcion Categoria,m.Descripcion Marca,ImagenUrl,Precio,a.IdCategoria,a.IdMarca,a.Id from ARTICULOS a, CATEGORIAS c, MARCAS m where c.Id=IdCategoria and m.Id=IdMarca and a.Id=@Id");
                conexion.setearparametros("@Id", Id);
                conexion.ejecutarlectura();

                while (conexion.Lector.Read())
                {
                    Articulo arti = new Articulo();
                    arti.Codigo = (string)conexion.Lector["Codigo"];
                    arti.Nombre = (string)conexion.Lector["Nombre"];
                    if (conexion.Lector != null)
                    {
                        arti.Imagen = (string)conexion.Lector["ImagenUrl"];
                    }
                    arti.Descripcion = (string)conexion.Lector["Descripcion"];
                    arti.Precio = (decimal)conexion.Lector["Precio"];
                    arti.Marca = new Marcas();
                    arti.Marca.marca = (string)conexion.Lector["Marca"];
                    arti.Marca.id = (int)conexion.Lector["IdMarca"];
                    arti.categoria = new Categoria();
                    arti.categoria.categoria = (string)conexion.Lector["categoria"];
                    arti.categoria.Id = (int)conexion.Lector["IdCategoria"];
                    arti.Id = (int)conexion.Lector["Id"];
                    lista.Add(arti);
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
        public void AgregarArticulo(Articulo elegido)
        {
            ConexionDB conex = new ConexionDB();
            try
            {
                conex.setearconsulta("insert into ARTICULOS(Codigo,Nombre, Descripcion, IdMarca,IdCategoria,ImagenUrl,Precio)values(@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio) ");
                conex.setearparametros("@Codigo", elegido.Codigo);
                conex.setearparametros("@Nombre", elegido.Nombre);
                conex.setearparametros("@Descripcion", elegido.Descripcion);
                conex.setearparametros("@IdMarca", elegido.Marca.id);
                conex.setearparametros("@IdCategoria", elegido.categoria.Id);
                conex.setearparametros("@ImagenUrl", elegido.Imagen);
                conex.setearparametros("@Precio", elegido.Precio);
                conex.ejecutaraccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conex.cerrarconexion();
            }
        }
        public void Modificar(Articulo elegi)
        {
            ConexionDB cone = new ConexionDB();

            try
            {
                cone.setearconsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                cone.setearparametros("@Codigo", elegi.Codigo);
                cone.setearparametros("@Nombre", elegi.Nombre);
                cone.setearparametros("@Descripcion", elegi.Descripcion);
                cone.setearparametros("@IdMarca", elegi.Marca.id);
                cone.setearparametros("@IdCategoria", elegi.categoria.Id);
                cone.setearparametros("@ImagenUrl", elegi.Imagen);
                cone.setearparametros("@Precio", elegi.Precio);
                cone.setearparametros("@Id", elegi.Id);
                cone.ejecutaraccion();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally { cone.cerrarconexion(); }
        }
        public void eliminar(string articc)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.setearconsulta("delete ARTICULOS where Id = @Id");
                con.setearparametros("@Id", articc);
                con.ejecutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.cerrarconexion(); }

        }
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> articulosfiltrados = new List<Articulo>();
            ConexionDB conec = new ConexionDB();
            try
            {
                string consulta = ("select Codigo,Nombre,a.Descripcion,c.Descripcion Categoria,m.Descripcion Marca,ImagenUrl,Precio,a.IdCategoria,a.IdMarca,a.Id from ARTICULOS a, CATEGORIAS c, MARCAS m where c.Id=IdCategoria and m.Id=IdMarca and  ");
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio >" + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio <" + filtro;
                                break;
                            default:
                                consulta += "precio =" + filtro;
                                break;
                        }
                        break;
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Empienza con":
                                consulta += "Codigo like '" +filtro+ "%'";
                                break;
                            case "Termina con":
                                consulta += "Codigo like '%" + filtro+ "'";
                                break;
                            case "Contiene":
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }
                conec.setearconsulta(consulta);
                conec.ejecutarlectura();
                while (conec.Lector.Read())
                {
                    Articulo arti = new Articulo();
                    arti.Codigo = (string)conec.Lector["Codigo"];
                    arti.Nombre = (string)conec.Lector["Nombre"];
                    if (conec.Lector != null)
                    {
                        arti.Imagen = (string)conec.Lector["ImagenUrl"];
                    }
                    arti.Descripcion = (string)conec.Lector["Descripcion"];
                    arti.Precio = (decimal)conec.Lector["Precio"];
                    arti.Marca = new Marcas();
                    arti.Marca.marca = (string)conec.Lector["Marca"];
                    arti.Marca.id = (int)conec.Lector["IdMarca"];
                    arti.categoria = new Categoria();
                    arti.categoria.categoria = (string)conec.Lector["categoria"];
                    arti.categoria.Id = (int)conec.Lector["IdCategoria"];
                    arti.Id = (int)conec.Lector["Id"];
                    articulosfiltrados.Add(arti);
                }

                return articulosfiltrados;
            }catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conec.cerrarconexion();
            } 
            
        }
    } 
}
