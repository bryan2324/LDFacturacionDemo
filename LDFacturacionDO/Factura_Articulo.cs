using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDFacturacionDO
{
    public class Factura_Articulo
    {
        public int codigo { get; set; }
        public int idFactura { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public decimal precio { get; set; }
    }
}
