using POOI_ProyectoVentas_AltamiranoBryan.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace POOI_ProyectoVentas_AltamiranoBryan.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.articulo.ToList());
            }
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                var art = context.articulo.Where(x => x.idarticulo == id).FirstOrDefault();
                if (art == null)
                {
                    return HttpNotFound();
                }
                return View(art);
            }
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(articulo art)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.articulo.Add(art);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                var art = context.articulo.Where(x => x.idarticulo == id).FirstOrDefault();
                if (art == null)
                {
                    return HttpNotFound();
                }
                return View(art);
            }
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, articulo art)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(art).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                var art = context.articulo.Where(x => x.idarticulo == id).FirstOrDefault();
                if (art == null)
                {
                    return HttpNotFound();
                }
                return View(art);
            }
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    articulo art = context.articulo.Where(x => x.idarticulo == id).FirstOrDefault();
                    context.articulo.Remove(art);
                    context.SaveChanges();
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
