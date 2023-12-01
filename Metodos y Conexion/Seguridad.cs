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
            if (Logueado != null)
            {
                return true;
            }
            else return false;
        }
        public bool Admin(User Logueado)
        {
            if(Logueado.Admin)
            {
                return true;
            }
            return false;
        }
        public bool EmailVacio()
        {
            
            return false;
        }
    }
    
}
