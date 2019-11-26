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
    public class ReportesController : Controller
    {
        private ConexionDBxUD db = new ConexionDBxUD();

        // GET: Reportes
        public ActionResult Index()
        {
            var rEPORTE = db.REPORTE.Include(r => r.SONDEO);
            return View(rEPORTE.ToList());
        }

        // GET: Reportes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTE rEPORTE = db.REPORTE.Find(id);
            if (rEPORTE == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTE);
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION");
            return View();
        }

        // POST: Reportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_REPORTE,ID_SONDEO,ID_USUARIO,FECHA_REPORTE")] REPORTE rEPORTE)
        {
            if (ModelState.IsValid)
            {
                db.REPORTE.Add(rEPORTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", rEPORTE.ID_SONDEO);
            return View(rEPORTE);
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTE rEPORTE = db.REPORTE.Find(id);
            if (rEPORTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", rEPORTE.ID_SONDEO);
            return View(rEPORTE);
        }

        // POST: Reportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_REPORTE,ID_SONDEO,ID_USUARIO,FECHA_REPORTE")] REPORTE rEPORTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEPORTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", rEPORTE.ID_SONDEO);
            return View(rEPORTE);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTE rEPORTE = db.REPORTE.Find(id);
            if (rEPORTE == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTE);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            REPORTE rEPORTE = db.REPORTE.Find(id);
            db.REPORTE.Remove(rEPORTE);
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
