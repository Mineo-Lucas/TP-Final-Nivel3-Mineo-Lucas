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
        public bool Contraseña(string contraseña, int id)
        {
            ConexionDB conec = new ConexionDB();
            try
            {
                conec.setearconsulta("select pass from USERS where Id= @Id");
                conec.setearparametros("@Id", id);
                conec.ejecutarlectura();
                if (conec.Lector.Read())
                {
                    string contra = conec.Lector["pass"].ToString();
                    if (contraseña== contra)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ValidarVacioNull(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
