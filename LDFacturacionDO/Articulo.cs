using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDFacturacionDO
{
    public class Articulo
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public decimal costo { get; set; }
        public bool activo { get; set; }
    }
}
