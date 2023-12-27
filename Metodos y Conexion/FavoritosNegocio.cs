using clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_y_Conexion
{
    public class FavoritosNegocio
    {
        public List<Articulo> ListarFavoritos(int id)
        {
            List<Articulo> articulos = new List<Articulo>();
            ConexionDB conec = new ConexionDB();
            try
            {
                conec.setearconsulta("select Codigo,a.Nombre,a.Descripcion,c.Descripcion Categoria,m.Descripcion Marca,ImagenUrl,Precio,a.IdCategoria,a.IdMarca, f.IdArticulo, a.Id, f.IdUser, u.Id from ARTICULOS a, CATEGORIAS c, MARCAS m, FAVORITOS f, USERS u where u.Id=@Id and u.Id=f.IdUser and f.IdArticulo=a.Id and c.Id=IdCategoria and m.Id=IdMarca");
                conec.setearparametros("@Id", id);
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
                    articulos.Add(arti);
                }

                return articulos;
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
        public void AgregarArticuloFavoritos(Favorito favorito)
        {
            ConexionDB conex = new ConexionDB();
            try
            {
                conex.setearconsulta("insert into FAVORITOS(IdUser, IdArticulo)values(@IdUser,@IdArticulo)");
                conex.setearparametros("@IdUser", favorito.IdUsuario);
                conex.setearparametros("@IdArticulo", favorito.IdArticulo);
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

    }
}
