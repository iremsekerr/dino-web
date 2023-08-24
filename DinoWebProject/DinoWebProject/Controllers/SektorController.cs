using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinoWebProject.Controllers
{
    public class SektorController : Controller
    {
        // GET: Sektor
        DbDinoWebEntities _context = new DbDinoWebEntities();
        Class cs = new Class();
        public ActionResult Sektorler()
        {
            cs.Sectors = _context.Sector.ToList();
            return View(cs);
        }
        public ActionResult SektorDetay(int id)
        {
            cs.Sectors = _context.Sector.Where(x => x.Id == id);
            ViewBag.modal = _context.Sector.ToList(); // Burada ViewBag.modal'ı dolduruyoruz
            return View(cs);
        }

    }
}