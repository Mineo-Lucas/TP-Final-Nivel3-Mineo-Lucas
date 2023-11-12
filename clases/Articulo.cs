using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    public class Articulo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public Marcas Marca{ get; set; }
        public Categoria categoria { get; set; }
        public int Id { get; set; }
    }
    
}
