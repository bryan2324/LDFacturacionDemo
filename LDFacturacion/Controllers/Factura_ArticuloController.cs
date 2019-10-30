using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LDFacturacion.Controllers
{
    public class Factura_ArticuloController : Controller
    {
        public ActionResult Index()
        {
            string IdFacturacion = Session["idFactura"].ToString();
            LDFacturacionBBL.MantenimientoFactura__Articulo._Instancia.Mostrar();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Factura_Articulo/Create
        [HttpPost]
        public ActionResult Create(Factura_Articulo factura_articulo)
        {
            try
            {
                string idFacturaTemp = Session["idFactura"].ToString();
                factura_articulo.idFactura = Convert.ToInt32(idFacturaTemp);
                bool existe = LDFacturacionBBL.MantenimientoFactura__Articulo._Instancia.ExisteEnFactura(factura_articulo.codigo, Convert.ToInt32(idFacturaTemp));

                if (LDFacturacionBBL.MantenimientoArticulos._Instancia.ValidarItem(factura_articulo.codigo) && !existe)
                {
                    LDFacturacionBBL.MantenimientoFactura__Articulo._Instancia.Insertar(factura_articulo);
                    return RedirectToAction("../Factura/Preview");
                }
                else if (existe) {
                    TempData["msg"] = "<script>alert('El articulo ya esta agregado en la factura');</script>";
                    return View();
                }
                else
                {
                    TempData["msg"] = "<script>alert('El articulo no existe o esta inactivo');</script>";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: Factura_Articulo/Delete
        public ActionResult Delete()
        {
            try
            {
                string IdFacturacion = Session["idFactura"].ToString();
                LDFacturacionDO.Factura factura = new LDFacturacionDO.Factura();
                LDFacturacionDO.Factura_Articulo facturaArticulo = new LDFacturacionDO.Factura_Articulo();
                facturaArticulo.idFactura = Convert.ToInt32(IdFacturacion);
                factura.idFactura = Convert.ToInt32(IdFacturacion);
                LDFacturacionBBL.MantenimientoFactura__Articulo._Instancia.Eliminar(facturaArticulo);
                LDFacturacionBBL.MantenimientoFacturas._Instancia.Eliminar(factura);
                Session.Abandon();
                return RedirectToAction("../Factura/Index");
            }
            catch
            {
                return RedirectToAction("../Factura/Index");
            }
        }
    }
}
