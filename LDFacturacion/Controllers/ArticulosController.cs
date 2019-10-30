using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LDFacturacion.Controllers
{
    public class ArticulosController : Controller
    {
        public ActionResult Index()
        {
            List<Articulo> articulo = new List<Articulo>();
            articulo = LDFacturacionBBL.MantenimientoArticulos._Instancia.Mostrar();
            return View(articulo.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        [HttpPost]
        public ActionResult Create(Articulo articulo)
        {
            try
            {
                LDFacturacionBBL.MantenimientoArticulos._Instancia.Insertar(articulo);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Ya existe un artículo con ese codigo');</script>";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                List<Articulo> articulo = new List<Articulo>();
                articulo = LDFacturacionBBL.MantenimientoArticulos._Instancia.MostrarPorCodigo(id);
                return View(articulo.FirstOrDefault());
            }
            catch (Exception)
            {
                return View("Index");
            }
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        public ActionResult Edit(Articulo articulo)
        {
            try
            {
                LDFacturacionBBL.MantenimientoArticulos._Instancia.Actualizar(articulo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Articulos/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Articulo articulo = new Articulo();
                articulo.codigo = id;
                LDFacturacionBBL.MantenimientoArticulos._Instancia.Eliminar(articulo);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Este artículo no puede ser eliminado');</script>";
                return RedirectToAction("Index");
            }
        }
    }
}
