using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LDFacturacion.Controllers
{
    public class FacturaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Factura/Details/5
        public ActionResult Delete(int id)
        {
            string IdFacturacion = Session["idFactura"].ToString();
            Factura_Articulo factura_Articulo = new Factura_Articulo();
            factura_Articulo.codigo = id;
            factura_Articulo.idFactura = Convert.ToInt32(IdFacturacion);
            LDFacturacionBBL.MantenimientoFactura__Articulo._Instancia.EliminarItemFactura(factura_Articulo);

            return RedirectToAction("../Factura/Preview");
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Factura/Create
        [HttpPost]
        public ActionResult Create(Factura factura)
        {
            try
            {
                LDFacturacionBBL.MantenimientoFacturas._Instancia.Insertar(factura);
                string ultimoIdFactura = Convert.ToString(LDFacturacionBBL.MantenimientoFacturas._Instancia.ultimoIdFactura());
                Session["idFactura"] = ultimoIdFactura;
                return RedirectToAction("../Factura/Preview");
            
            }catch
            {
                return View();
            }
        }

        public ActionResult Show()
        {
            string IdFacturacion = Session["idFactura"].ToString();
            List<Factura> facturacion = new List<Factura>();
            facturacion = LDFacturacionBBL.MantenimientoFacturas._Instancia.MostrarFactura(Convert.ToInt32(IdFacturacion));
            Session.Abandon();
            return View(facturacion.ToList());
        }

        public ActionResult Preview()
        {
            string IdFacturacion = Session["idFactura"].ToString();
            List<Factura> facturacion = new List<Factura>();
            facturacion = LDFacturacionBBL.MantenimientoFacturas._Instancia.MostrarFactura(Convert.ToInt32(IdFacturacion));
            return View(facturacion.ToList());
        }
    }
}
