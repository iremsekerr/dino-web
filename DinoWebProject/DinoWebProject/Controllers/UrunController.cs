using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinoWebProject.Controllers
{
    public class UrunController : Controller
    {
        DbDinoWebEntities _context = new DbDinoWebEntities();
        Class cs = new Class();
        public ActionResult Urunler()
        {
            cs.Products = _context.Product.ToList();
            return View(cs);
        }
        public ActionResult UrunDetay(int id) 
        {
            cs.Products = _context.Product.Where(x => x.Id == id);
            ViewBag.modal = _context.Product.ToList();
            return View(cs);
        }
    }
}