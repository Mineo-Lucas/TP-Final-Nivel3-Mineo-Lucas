using clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_y_Conexion
{
    public class FavoritosNegocio
    {
        public List<Articulo> ListarFavoritos()
        {
            List<Articulo> catego = new List<Articulo>();
            ConexionDB conec = new ConexionDB();
            try
            {
                conec.setearconsulta("select Id,Descripcion from CATEGORIAS");
                conec.ejecutarlectura();


                while (conec.Lector.Read())
                {
                    Categoria cate = new Categoria();
                    cate.Id = (int)conec.Lector["Id"];
                    cate.categoria = (string)conec.Lector["Descripcion"];
                    //catego.Add(cate);
                }
                return catego;
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
