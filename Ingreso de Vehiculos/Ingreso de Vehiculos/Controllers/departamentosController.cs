using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ingreso_de_Vehiculos.Models;

namespace Ingreso_de_Vehiculos.Controllers
{
    public class departamentosController : Controller
    {
        private DB_A1E868_ingresoCTPEntities db = new DB_A1E868_ingresoCTPEntities();

        // GET: departamentos
        public ActionResult Index()
        {
            return View(db.departamentos.ToList());
        }
        // GET: departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_departamento,nombre,descripcion")] departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                db.departamentos.Add(departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamentos);
        }

        // GET: departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamentos departamentos = db.departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
        }

        // POST: departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_departamento,nombre,descripcion")] departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamentos);
        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
