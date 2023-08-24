using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinoWebProject.Controllers
{
    public class HaberController : Controller
    {
        DbDinoWebEntities _context = new DbDinoWebEntities();
        Class cs = new Class();
        public ActionResult Haberler()
        {
            cs.News = _context.News.ToList();
            ViewBag.modal = _context.News.ToList();
            return View(cs);
        }
        public ActionResult HaberDetay(int id) 
        {
            cs.News = _context.News.Where(x => x.Id == id);
            ViewBag.modal = _context.News.ToList(); // Burada ViewBag.modal'ı dolduruyoruz
            return View(cs);
        }
    }
}