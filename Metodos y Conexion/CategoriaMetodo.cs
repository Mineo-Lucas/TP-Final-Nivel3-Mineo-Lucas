using clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_y_Conexion
{
    public class CategoriaMetodo
    {
        public List<Categoria> listarcategoria()
        {
            List<Categoria> catego = new List<Categoria>();
            ConexionDB conec=new ConexionDB();
            try
            {
                conec.setearconsulta("select Id,Descripcion from CATEGORIAS");
                conec.ejecutarlectura();
                

                while (conec.Lector.Read())
                {
                    Categoria cate=new Categoria();
                    cate.Id = (int)conec.Lector["Id"];
                    cate.categoria = (string)conec.Lector["Descripcion"];
                    catego.Add(cate);
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
    }
}
