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
    [Authorize(Roles = "usuariodefinitivo")]
    public class ProductosController : Controller
    {
        private ConexionDBxUD db = new ConexionDBxUD();

        // GET: Productos
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.CATEGORIA).Include(p => p.MARCA).Include(p => p.MEDIDA).Include(p => p.SONDEO);
            return View(pRODUCTO.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "CATEGORIA1");
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "MARCA1");
            ViewBag.UNIDAD_MEDIDA = new SelectList(db.MEDIDA, "ID_MEDIDA", "MEDIDA1");
            ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,ID_CATEGORIA,UNIDAD_MEDIDA,ID_MARCA,PRODUCTO1,PRESENTACION,PRECIO_CONSULTA,TIPO,ALPORMAYOR,ID_SONDEO,CANTIDAD_MEDIDA")] PRODUCTO pRODUCTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PRODUCTO.Add(pRODUCTO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "CATEGORIA1", pRODUCTO.ID_CATEGORIA);
                ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "MARCA1", pRODUCTO.ID_MARCA);
                ViewBag.UNIDAD_MEDIDA = new SelectList(db.MEDIDA, "ID_MEDIDA", "MEDIDA1", pRODUCTO.UNIDAD_MEDIDA);
                ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", pRODUCTO.ID_SONDEO);
                return View(pRODUCTO);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Ocurrio un error al intentar agregar un producto");
                    return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "CATEGORIA1", pRODUCTO.ID_CATEGORIA);
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "MARCA1", pRODUCTO.ID_MARCA);
            ViewBag.UNIDAD_MEDIDA = new SelectList(db.MEDIDA, "ID_MEDIDA", "MEDIDA1", pRODUCTO.UNIDAD_MEDIDA);
            ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", pRODUCTO.ID_SONDEO);
            return View(pRODUCTO);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,ID_CATEGORIA,UNIDAD_MEDIDA,ID_MARCA,PRODUCTO1,PRESENTACION,PRECIO_CONSULTA,TIPO,ALPORMAYOR,ID_SONDEO,CANTIDAD_MEDIDA")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "CATEGORIA1", pRODUCTO.ID_CATEGORIA);
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "MARCA1", pRODUCTO.ID_MARCA);
            ViewBag.UNIDAD_MEDIDA = new SelectList(db.MEDIDA, "ID_MEDIDA", "MEDIDA1", pRODUCTO.UNIDAD_MEDIDA);
            ViewBag.ID_SONDEO = new SelectList(db.SONDEO, "ID_SONDEO", "DESCRIPCION", pRODUCTO.ID_SONDEO);
            return View(pRODUCTO);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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
