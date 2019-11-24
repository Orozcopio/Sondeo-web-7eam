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
    public class ProductosEnSondeosController : Controller
    {
        private Conexion_UD db = new Conexion_UD();

        // GET: ProductosEnSondeos
        public ActionResult Index()
        {
            var productosEnSondeo = db.ProductosEnSondeo.Include(p => p.PRODUCTO).Include(p => p.SONDEO);
            return View(productosEnSondeo.ToList());
        }

        // GET: ProductosEnSondeos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosEnSondeo productosEnSondeo = db.ProductosEnSondeo.Find(id);
            if (productosEnSondeo == null)
            {
                return HttpNotFound();
            }
            return View(productosEnSondeo);
        }

        // GET: ProductosEnSondeos/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.PRODUCTO, "ID_PRODUCTO", "ID_CATEGORIA");
            ViewBag.SondeoID = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION");
            return View();
        }

        // POST: ProductosEnSondeos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SondeoID,ProductoID,ID")] ProductosEnSondeo productosEnSondeo)
        {
            if (ModelState.IsValid)
            {
                db.ProductosEnSondeo.Add(productosEnSondeo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.PRODUCTO, "ID_PRODUCTO", "ID_CATEGORIA", productosEnSondeo.ProductoID);
            ViewBag.SondeoID = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", productosEnSondeo.SondeoID);
            return View(productosEnSondeo);
        }

        // GET: ProductosEnSondeos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosEnSondeo productosEnSondeo = db.ProductosEnSondeo.Find(id);
            if (productosEnSondeo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoID = new SelectList(db.PRODUCTO, "ID_PRODUCTO", "ID_CATEGORIA", productosEnSondeo.ProductoID);
            ViewBag.SondeoID = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", productosEnSondeo.SondeoID);
            return View(productosEnSondeo);
        }

        // POST: ProductosEnSondeos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SondeoID,ProductoID,ID")] ProductosEnSondeo productosEnSondeo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosEnSondeo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoID = new SelectList(db.PRODUCTO, "ID_PRODUCTO", "ID_CATEGORIA", productosEnSondeo.ProductoID);
            ViewBag.SondeoID = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", productosEnSondeo.SondeoID);
            return View(productosEnSondeo);
        }

        // GET: ProductosEnSondeos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosEnSondeo productosEnSondeo = db.ProductosEnSondeo.Find(id);
            if (productosEnSondeo == null)
            {
                return HttpNotFound();
            }
            return View(productosEnSondeo);
        }

        // POST: ProductosEnSondeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductosEnSondeo productosEnSondeo = db.ProductosEnSondeo.Find(id);
            db.ProductosEnSondeo.Remove(productosEnSondeo);
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
