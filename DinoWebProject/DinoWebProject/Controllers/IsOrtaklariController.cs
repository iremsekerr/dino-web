using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinoWebProject.Controllers
{
    public class IsOrtaklariController : Controller
    {
        DbDinoWebEntities _context = new DbDinoWebEntities();
        Class cs = new Class();
        // GET: IsOrtaklari
        
        public ActionResult DinosoftİsOrtakligi()
        {
            cs.Contents = _context.Contents.ToList();
            return View(cs);
        }
        public ActionResult IsOrtakligiBasvuru()
        {
            cs.Contents = _context.Contents.ToList();
            return View(cs);
        }


    }
}