using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using clases;
using System.Security.Cryptography.X509Certificates;


namespace Metodos_y_Conexion
{
    public class ConexionDB
    {
       private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }



        public ConexionDB()
        {
            try
            {
                conexion=new SqlConnection("Server=DESKTOP-E7IU7EN\\SQLEXPRESS;DataBase=CATALOGO_WEB_DB;integrated security=true");
                comando = new SqlCommand();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setearconsulta(string consulta) 
        {
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }
        public void setearparametros(string nombre, object value)
        {
            comando.Parameters.AddWithValue(nombre, value);

        }
        public void ejecutarlectura()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                lector=comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }
        public void ejecutaraccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EjecutarAccionScalar()
        {
            comando.Connection= conexion;

            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void cerrarconexion()
        {
            if (lector!=null)
            { 
                lector.Close();
            } 
            conexion.Close();        
        }

            
           
           
            







       
    }
}
