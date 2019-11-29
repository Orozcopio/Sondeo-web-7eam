using Sondeo_web_7eam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Sondeo_web_7eam.Controllers
{
    public class HomeController : Controller
    {
        private ConexionDBxUD db = new ConexionDBxUD();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listaProductos()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.CATEGORIA).Include(p => p.MARCA).Include(p => p.MEDIDA).Include(p => p.SONDEO);
            return View(pRODUCTO.ToList());
        }

        public ActionResult exportarReporte()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.CATEGORIA).Include(p => p.MARCA).Include(p => p.MEDIDA).Include(p => p.SONDEO);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes"), "CrystalReport.rtp"));
            rd.SetDataSource(pRODUCTO.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Reporte_Productos.pdf");
            }
            catch (Exception)
            {

                throw;
            }

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}