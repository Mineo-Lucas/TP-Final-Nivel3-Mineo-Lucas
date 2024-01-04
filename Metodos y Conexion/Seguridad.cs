using clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_y_Conexion
{
    public class Seguridad
    {
        public bool SesionActiva(User Logueado)
        {
            try
            {
                if (Logueado != null)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public bool Admin(User Logueado)
        {
            try
            {
                User admin = Logueado;
                if (admin.Admin == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool EmailVacio()
        {
            
            return false;
        }
        public bool EmailRepetido(string email)
        {
            ConexionDB conexion = new ConexionDB();
            conexion.setearconsulta("select email from USERS where email=@email");
            conexion.setearparametros("@Email", email);
            conexion.ejecutarlectura();
            if (conexion.Lector.Read())
            {
                return true;
            }
            return false;
        }
    }
    
}
