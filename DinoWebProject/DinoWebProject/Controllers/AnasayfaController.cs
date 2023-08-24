using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinoWebProject.Controllers
{
    public class AnasayfaController : Controller
    {
        DbDinoWebEntities _context = new DbDinoWebEntities();
        Class cs = new Class();
        public ActionResult Index()
        {
            cs.Contents = _context.Contents.ToList();
            cs.News = _context.News.ToList();
            cs.Products = _context.Product.ToList();
            cs.Sectors = _context.Sector.ToList();
            return View(cs);
        }
       
        public PartialViewResult _NavbarSectorList() 
        {
            SectorModel sector =new SectorModel();
            sector.Sectors = _context.Sector.ToList();
            return PartialView(sector);
        }
        public PartialViewResult _NavbarProductList()
        {
            ProductModel product = new ProductModel();
            product.Products = _context.Product.ToList();
            return PartialView(product);
        }
        public PartialViewResult _FooterProductList()
        {
            ProductModel product = new ProductModel();
            product.Products = _context.Product.ToList();
            return PartialView(product);
        }
        public PartialViewResult _FooterNewsList()
        {
            NewsModel news = new NewsModel();
            news.News = _context.News.ToList();
            return PartialView(news);
        }
        public PartialViewResult _MobileMenuSectorList()
        {
            SectorModel sector = new SectorModel();
            sector.Sectors = _context.Sector.ToList();
            return PartialView(sector);
        }
        public PartialViewResult _MobileMenuProductList()
        {
            ProductModel product = new ProductModel();
            product.Products = _context.Product.ToList();
            return PartialView(product); ;
        }
    }
}