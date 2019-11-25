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
    public class MedidasController : Controller
    {
        private ConexionDB db = new ConexionDB();

        // GET: Medidas
        public ActionResult Index()
        {
            return View(db.MEDIDA.ToList());
        }

        // GET: Medidas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDIDA mEDIDA = db.MEDIDA.Find(id);
            if (mEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(mEDIDA);
        }

        // GET: Medidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UNIDAD_MEDIDA,CANTIDAD")] MEDIDA mEDIDA)
        {
            if (ModelState.IsValid)
            {
                db.MEDIDA.Add(mEDIDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mEDIDA);
        }

        // GET: Medidas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDIDA mEDIDA = db.MEDIDA.Find(id);
            if (mEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(mEDIDA);
        }

        // POST: Medidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UNIDAD_MEDIDA,CANTIDAD")] MEDIDA mEDIDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEDIDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEDIDA);
        }

        // GET: Medidas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDIDA mEDIDA = db.MEDIDA.Find(id);
            if (mEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(mEDIDA);
        }

        // POST: Medidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MEDIDA mEDIDA = db.MEDIDA.Find(id);
            db.MEDIDA.Remove(mEDIDA);
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
