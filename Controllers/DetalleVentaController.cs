using POOI_ProyectoVentas_AltamiranoBryan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POOI_ProyectoVentas_AltamiranoBryan.Controllers
{
    public class DetalleVentaController : Controller
    {
        // GET: DetalleVenta
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                var detalles = context.detalle_venta.Include(d => d.articulo).ToList();
                return View(detalles);
            }
        }

        // GET: DetalleVenta/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                var detalle = context.detalle_venta.Include(d => d.articulo).FirstOrDefault(d => d.iddetalle_venta == id);
                if (detalle == null)
                {
                    return HttpNotFound();
                }
                return View(detalle);
            }
        }

        // GET: DetalleVenta/Create
        public ActionResult Create()
        {
            using (DbModels context = new DbModels())
            {
                ViewBag.Articulos = new SelectList(context.articulo.ToList(), "idarticulo", "nombre"); // Cambia "nombre" por la propiedad correspondiente
                return View();
            }
        }

        // POST: DetalleVenta/Create
        [HttpPost]
        public ActionResult Create(detalle_venta detalle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.detalle_venta.Add(detalle);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(detalle);
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleVenta/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                var detalle = context.detalle_venta.Include(d => d.articulo).FirstOrDefault(d => d.iddetalle_venta == id);
                if (detalle == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Articulos = new SelectList(context.articulo.ToList(), "idarticulo", "nombre", detalle.idarticulo); // Cambia "nombre" por la propiedad correspondiente
                return View(detalle);
            }
        }

        // POST: DetalleVenta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, detalle_venta detalle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Entry(detalle).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(detalle);
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleVenta/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                var detalle = context.detalle_venta.Include(d => d.articulo).FirstOrDefault(d => d.iddetalle_venta == id);
                if (detalle == null)
                {
                    return HttpNotFound();
                }
                return View(detalle);
            }
        }

        // POST: DetalleVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    var detalle = context.detalle_venta.Find(id);
                    if (detalle != null)
                    {
                        context.detalle_venta.Remove(detalle);
                        context.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
