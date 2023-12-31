using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_y_Conexion
{
    public class Validaciones
    {
        public bool ValidarVacioNull(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
