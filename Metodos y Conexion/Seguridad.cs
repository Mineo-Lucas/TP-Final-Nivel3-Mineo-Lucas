using clases;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    
}
