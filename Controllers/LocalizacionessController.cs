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
    public class LocalizacionessController : Controller
    {
        private ConexionDBxUD db = new ConexionDBxUD();

        // GET: Localizacioness
        public ActionResult Index()
        {
            var lOCALIZACION = db.LOCALIZACION.Include(l => l.DEPARTAMENTOS).Include(l => l.MUNICIPIOS);
            return View(lOCALIZACION.ToList());
        }

        // GET: Localizacioness/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOCALIZACION lOCALIZACION = db.LOCALIZACION.Find(id);
            if (lOCALIZACION == null)
            {
                return HttpNotFound();
            }
            return View(lOCALIZACION);
        }

        // GET: Localizacioness/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO");
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO");
            return View();
        }

        // POST: Localizacioness/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOCAL,LOCALIDAD,DEPARTAMENTO,MUNICIPIO,AREA")] LOCALIZACION lOCALIZACION)
        {
            if (ModelState.IsValid)
            {
                db.LOCALIZACION.Add(lOCALIZACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO", lOCALIZACION.DEPARTAMENTO);
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO", lOCALIZACION.MUNICIPIO);
            return View(lOCALIZACION);
        }

        // GET: Localizacioness/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOCALIZACION lOCALIZACION = db.LOCALIZACION.Find(id);
            if (lOCALIZACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO", lOCALIZACION.DEPARTAMENTO);
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO", lOCALIZACION.MUNICIPIO);
            return View(lOCALIZACION);
        }

        // POST: Localizacioness/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOCAL,LOCALIDAD,DEPARTAMENTO,MUNICIPIO,AREA")] LOCALIZACION lOCALIZACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOCALIZACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO", lOCALIZACION.DEPARTAMENTO);
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO", lOCALIZACION.MUNICIPIO);
            return View(lOCALIZACION);
        }

        // GET: Localizacioness/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOCALIZACION lOCALIZACION = db.LOCALIZACION.Find(id);
            if (lOCALIZACION == null)
            {
                return HttpNotFound();
            }
            return View(lOCALIZACION);
        }

        // POST: Localizacioness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOCALIZACION lOCALIZACION = db.LOCALIZACION.Find(id);
            db.LOCALIZACION.Remove(lOCALIZACION);
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
