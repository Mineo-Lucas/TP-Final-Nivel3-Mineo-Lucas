using clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_y_Conexion
{
    public class MarcasMetodo
    {
        public List<Marcas> listarMarcas()
        {
            List<Marcas> marcaas = new List<Marcas>();
            ConexionDB conec = new ConexionDB();
            try
            {
                conec.setearconsulta("select Id,Descripcion from MARCAS");
                conec.ejecutarlectura();


                while (conec.Lector.Read())
                {
                    Marcas marca = new Marcas();
                    marca.id = (int)conec.Lector["Id"];
                    marca.marca = (string)conec.Lector["Descripcion"];
                    marcaas.Add(marca);
                }
                return marcaas;
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
