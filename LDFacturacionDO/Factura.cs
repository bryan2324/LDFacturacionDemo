using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDFacturacionDO
{
    public class Factura
    {
        public int idFactura { get; set; }
        public string cliente { get; set; }
        public DateTime fecha { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public List<Factura_Articulo> Items { get; set; }
    }
}
