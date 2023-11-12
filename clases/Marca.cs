using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    public class Marcas
    {
        public int id { get; set; }
        public string marca { get; set; }

        public override string ToString()
        {
            return marca;
        }
    }
}
