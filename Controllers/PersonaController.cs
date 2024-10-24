using POOI_ProyectoVentas_AltamiranoBryan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace POOI_ProyectoVentas_AltamiranoBryan.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.persona.ToList());
            }
               
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                var person = context.persona.Where(x => x.idpersona == id).FirstOrDefault();
                if (person == null)
                {
                    return HttpNotFound();
                }
                return View(person);
            }

        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(persona person)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.persona.Add(person);
                    context.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                var person = context.persona.Where(x => x.idpersona == id).FirstOrDefault();
                if (person == null)
                {
                    return HttpNotFound();
                }
                return View(person);
            }
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, persona person)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(person).State = EntityState.Modified;
                    context.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                var person = context.persona.Where(x => x.idpersona == id).FirstOrDefault();
                if (person == null)
                {
                    return HttpNotFound();
                }
                return View(person);
            }
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels context = new DbModels())
                {
                    persona person = context.persona.Where(x => x.idpersona == id).FirstOrDefault();
                    context.persona.Remove(person);
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
