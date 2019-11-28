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
        private ConexionDBxUD db = new ConexionDBxUD();

        // GET: Sondeos
        public ActionResult Index()
        {
            var sONDEO = db.SONDEO.Include(s => s.LOCALIZACION);
            return View(sONDEO.ToList());
        }

        // GET: Sondeos/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "ID_SONDEO,ID_LOCAL,FECHA,DESCRIPCION,FINALIZADO,ID_USUARIO")] SONDEO sONDEO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string logeado = User.Identity.Name.ToString();
                    string u = db.AspNetUsers.First(a => a.UserName == logeado).Id;
                    int local = db.LOCALIZACION.Where(a => a.CreadoPor == u).OrderByDescending(x => x.ID_LOCAL).First().ID_LOCAL;
                    sONDEO.ID_USUARIO = logeado;
                    sONDEO.FECHA = DateTime.Today;
                    sONDEO.ID_LOCAL = local;
                   
                    db.SONDEO.Add(sONDEO);
                    db.SaveChanges();
                    return RedirectToAction("../Productos/Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Algo salio mal, intente nuevamente"+ex);
                    return View(sONDEO);
                }
                
            }

            ViewBag.ID_LOCAL = new SelectList(db.LOCALIZACION, "ID_LOCAL", "LOCALIDAD", sONDEO.ID_LOCAL);
            return View(sONDEO);
        }

        // GET: Sondeos/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "ID_SONDEO,ID_LOCAL,FECHA,DESCRIPCION,FINALIZADO,ID_USUARIO")] SONDEO sONDEO)
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
