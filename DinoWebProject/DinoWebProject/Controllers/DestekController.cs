using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinoWebProject.Controllers
{
    public class DestekController : Controller
    {
        DbDinoWebEntities _context = new DbDinoWebEntities();
        Class cs = new Class();
        // GET: Destek
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UrunDestegi()
        {
            cs.Supports = _context.Support.ToList();
            return View(cs);
        }
        public ActionResult SatisDestegi()
        {
            cs.Supports = _context.Support.ToList();
            return View(cs);
        }
        public ActionResult DemoKurulumu()
        {
            cs.Supports = _context.Support.ToList();
            return View(cs);
        }
        public ActionResult DestekVideolari()
        {
            return View();

        }

    }
}