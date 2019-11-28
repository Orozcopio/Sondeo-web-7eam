using Sondeo_web_7eam.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sondeo_web_7eam.Controllers
{
    public class LocalizacionesController : Controller
    {
        private ConexionDBxUD db = new ConexionDBxUD();

        // GET: Localizaciones
        public ActionResult Index()
        {
            var lOCALIZACION = db.LOCALIZACION.Include(l => l.AspNetUsers).Include(l => l.DEPARTAMENTOS).Include(l => l.MUNICIPIOS);
            return View(lOCALIZACION.ToList());
        }

        // GET: Localizaciones/Details/5
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

        // GET: Localizaciones/Create
        public ActionResult Create()
        {
            ViewBag.CreadoPor = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO");
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO");
            return View();
        }

        // POST: Localizaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOCAL,LOCALIDAD,DEPARTAMENTO,MUNICIPIO,AREA,CreadoPor,DIRECCION")] LOCALIZACION lOCALIZACION)
        {
            if (ModelState.IsValid)
            {
                if((lOCALIZACION.DEPARTAMENTO==1&&(lOCALIZACION.MUNICIPIO>=1&&lOCALIZACION.MUNICIPIO<=12))||
                    (lOCALIZACION.DEPARTAMENTO == 1 && (lOCALIZACION.MUNICIPIO >= 1 && lOCALIZACION.MUNICIPIO <= 12))||
                    (lOCALIZACION.DEPARTAMENTO == 2 && (lOCALIZACION.MUNICIPIO >= 13 && lOCALIZACION.MUNICIPIO <= 21))||
                    (lOCALIZACION.DEPARTAMENTO == 3 && (lOCALIZACION.MUNICIPIO >= 22 && lOCALIZACION.MUNICIPIO <= 54))||
                    (lOCALIZACION.DEPARTAMENTO == 4 && (lOCALIZACION.MUNICIPIO >= 55 && lOCALIZACION.MUNICIPIO <= 70))||
                    (lOCALIZACION.DEPARTAMENTO == 5 && (lOCALIZACION.MUNICIPIO >= 71 && lOCALIZACION.MUNICIPIO <= 92))||
                    (lOCALIZACION.DEPARTAMENTO == 6 && (lOCALIZACION.MUNICIPIO >= 93 && lOCALIZACION.MUNICIPIO <= 114))||
                    (lOCALIZACION.DEPARTAMENTO == 7 && (lOCALIZACION.MUNICIPIO >= 115 && lOCALIZACION.MUNICIPIO <= 132))||
                    (lOCALIZACION.DEPARTAMENTO == 8 && (lOCALIZACION.MUNICIPIO >= 133 && lOCALIZACION.MUNICIPIO <= 158))||
                    (lOCALIZACION.DEPARTAMENTO == 9 && (lOCALIZACION.MUNICIPIO >= 159 && lOCALIZACION.MUNICIPIO <= 178))||
                    (lOCALIZACION.DEPARTAMENTO == 10 && (lOCALIZACION.MUNICIPIO >= 179 && lOCALIZACION.MUNICIPIO <= 197))||
                    (lOCALIZACION.DEPARTAMENTO == 11 && (lOCALIZACION.MUNICIPIO >= 196 && lOCALIZACION.MUNICIPIO <= 210))||
                    (lOCALIZACION.DEPARTAMENTO == 12 && (lOCALIZACION.MUNICIPIO >= 211 && lOCALIZACION.MUNICIPIO <= 223))||
                    (lOCALIZACION.DEPARTAMENTO == 13 && (lOCALIZACION.MUNICIPIO >= 224 && lOCALIZACION.MUNICIPIO <= 239))||
                    (lOCALIZACION.DEPARTAMENTO == 14 && (lOCALIZACION.MUNICIPIO >= 240 && lOCALIZACION.MUNICIPIO <= 262))
                    )
                {
                    try
                    {
                        string logeado = User.Identity.Name.ToString();
                        lOCALIZACION.CreadoPor = db.AspNetUsers.First(a => a.UserName == logeado).Id;
                        db.LOCALIZACION.Add(lOCALIZACION);
                        db.SaveChanges();
                        return RedirectToAction("../Sondeos/Create");
                    }
                    catch
                    {
                        ModelState.AddModelError("", "Ocurrio un error al ingresar la localizacion, intente nuevamente");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Hay un error en la localidad de Departamento o Municipio");
                    ViewBag.CreadoPor = new SelectList(db.AspNetUsers, "Id", "Email", lOCALIZACION.CreadoPor);
                    ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO", lOCALIZACION.DEPARTAMENTO);
                    ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO", lOCALIZACION.MUNICIPIO);
                    return View();
                }
                
            }

            ViewBag.CreadoPor = new SelectList(db.AspNetUsers, "Id", "Email", lOCALIZACION.CreadoPor);
            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO", lOCALIZACION.DEPARTAMENTO);
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO", lOCALIZACION.MUNICIPIO);
            return View(lOCALIZACION);
        }

        // GET: Localizaciones/Edit/5
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
            ViewBag.CreadoPor = new SelectList(db.AspNetUsers, "Id", "Email", lOCALIZACION.CreadoPor);
            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO", lOCALIZACION.DEPARTAMENTO);
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO", lOCALIZACION.MUNICIPIO);
            return View(lOCALIZACION);
        }

        // POST: Localizaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOCAL,LOCALIDAD,DEPARTAMENTO,MUNICIPIO,AREA,CreadoPor,DIRECCION")] LOCALIZACION lOCALIZACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOCALIZACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreadoPor = new SelectList(db.AspNetUsers, "Id", "Email", lOCALIZACION.CreadoPor);
            ViewBag.DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPTO", "DEPARTAMENTO", lOCALIZACION.DEPARTAMENTO);
            ViewBag.MUNICIPIO = new SelectList(db.MUNICIPIOS, "ID_MUN", "MUNICIPIO", lOCALIZACION.MUNICIPIO);
            return View(lOCALIZACION);
        }

        // GET: Localizaciones/Delete/5
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

        

        public ActionResult cancelar()
        {


            try
            {
                string logeado = User.Identity.Name.ToString();
                string u = db.AspNetUsers.First(a => a.UserName == logeado).Id;
                int ultimo = db.LOCALIZACION.Where(a => a.CreadoPor == u).OrderByDescending(x => x.ID_LOCAL).First().ID_LOCAL;
                string ban = ultimo.ToString();
                if(ban==null)
                {
                    ModelState.AddModelError("", "Algo salio mal, intente nuevamente");
                    return RedirectToAction("../Localizaciones/Create");
                }
                else
                {
                    LOCALIZACION lOCALIZACION = db.LOCALIZACION.Find(ultimo);
                    db.LOCALIZACION.Remove(lOCALIZACION);
                    db.SaveChanges();
                }
                
            }
            catch
            {
                ModelState.AddModelError("", "Algo salio mal, intente nuevamente");
                return RedirectToAction("../Localizaciones/Create");
            }
            


            return RedirectToAction("../Localizaciones/Create");
        }

        // POST: Localizaciones/Delete/5
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
