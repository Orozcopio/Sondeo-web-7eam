using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sondeo_web_7eam.Models;

namespace Sondeo_web_7eam.Controllers
{
    public class SondeosController : Controller
    {
        private Conexion_UD db = new Conexion_UD();

        // GET: Sondeos
        public ActionResult Index()
        {
            var sondeo = db.SONDEO.Include(s => s.LOCALIZACION);
            return View(sondeo.ToList());
        }

        // GET: Sondeos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SONDEO sONDEO = db.SONDEO.Find(id);
            if (sONDEO == null)
            {
                return HttpNotFound();
            }
            return View(sONDEO);
        }

        // GET: Sondeos/Create
        public ActionResult Create()
        {
            ViewBag.ID_LOCAL = new SelectList(db.LOCALIZACION, "ID_LOCAL", "LOCALIDAD");
            return View();
        }

        // POST: Sondeos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SONDEO,ID_LOCAL,FECHA,DESCRIPCION")] SONDEO sONDEO)
        {
            if (ModelState.IsValid)
            {
                db.SONDEO.Add(sONDEO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LOCAL = new SelectList(db.LOCALIZACION, "ID_LOCAL", "LOCALIDAD", sONDEO.ID_LOCAL);
            return View(sONDEO);
        }

        // GET: Sondeos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SONDEO sONDEO = db.SONDEO.Find(id);
            if (sONDEO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LOCAL = new SelectList(db.LOCALIZACION, "ID_LOCAL", "LOCALIDAD", sONDEO.ID_LOCAL);
            return View(sONDEO);
        }

        // POST: Sondeos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SONDEO,ID_LOCAL,FECHA,DESCRIPCION")] SONDEO sONDEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sONDEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LOCAL = new SelectList(db.LOCALIZACION, "ID_LOCAL", "LOCALIDAD", sONDEO.ID_LOCAL);
            return View(sONDEO);
        }

        // GET: Sondeos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SONDEO sONDEO = db.SONDEO.Find(id);
            if (sONDEO == null)
            {
                return HttpNotFound();
            }
            return View(sONDEO);
        }

        // POST: Sondeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SONDEO sONDEO = db.SONDEO.Find(id);
            db.SONDEO.Remove(sONDEO);
            db.SaveChanges();
            return RedirectToAction("Index");
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
