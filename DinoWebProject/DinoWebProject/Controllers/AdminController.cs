using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinoWebProject.Controllers
{
    public class AdminController : Controller
    {
        DbDinoWebEntities _context = new DbDinoWebEntities();
        Class cs = new Class();
        [Authorize]
        public ActionResult GetContentList()
        {
            cs.Contents = _context.Contents.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddContent(HttpPostedFileBase img, Contents c)
        {
            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Content"), fileName);
                img.SaveAs(path);

                c.Img = fileName;
            }

            _context.Contents.Add(c);
            _context.SaveChanges();
            return RedirectToAction("GetContentList");
        }

        public ActionResult RemoveContent(int id)
        {
            var content = _context.Contents.Find(id);

            if (content != null)
            {
                _context.Contents.Remove(content);
                _context.SaveChanges();
            }

            return RedirectToAction("GetContentList");
        }
        [HttpGet]
        public ActionResult UpdateContent(int id)
        {
            var contentToUpdate = _context.Contents.Find(id);
            if (contentToUpdate == null)
            {
                return HttpNotFound();
            }

            return View(contentToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateContent(HttpPostedFileBase img, Contents c)
        {
            var contentToUpdate = _context.Contents.Find(c.Id);
            if (contentToUpdate == null)
            {
                return HttpNotFound();
            }

            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Content"), fileName);
                img.SaveAs(path);

                contentToUpdate.Img = fileName;
            }
            contentToUpdate.Title = c.Title;
            contentToUpdate.FullText = c.FullText;
            contentToUpdate.OrderNumber = c.OrderNumber;

            _context.SaveChanges();
            return RedirectToAction("GetContentList");
        }


        [Authorize]
        public ActionResult GetProductList()
        {
            cs.Products = _context.Product.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddProduct(HttpPostedFileBase img, Product p)
        {
            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Product"), fileName);
                img.SaveAs(path);

                p.Img = fileName;
            }

            _context.Product.Add(p);
            _context.SaveChanges();
            return RedirectToAction("GetProductList");
        }
        public ActionResult RemoveProduct(int id)
        {
            var product = _context.Product.Find(id);

            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("GetProductList");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var productToUpdate = _context.Product.Find(id);
            if (productToUpdate == null)
            {
                return HttpNotFound();
            }

            return View(productToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateProduct(HttpPostedFileBase img, HttpPostedFileBase detailimg, Product p)
        {
            var productToUpdate = _context.Product.Find(p.Id);
            if (productToUpdate == null)
            {
                return HttpNotFound();
            }

            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Product"), fileName);
                img.SaveAs(path);

                productToUpdate.Img = fileName;
            }
            if (detailimg != null && detailimg.ContentLength > 0)
            {
                var fileName1 = Path.GetFileName(detailimg.FileName);
                var path1 = Path.Combine(Server.MapPath("~/Images/Product/Detail"), fileName1);
                detailimg.SaveAs(path1);

                productToUpdate.DetailImg = fileName1;

            }



            productToUpdate.Title = p.Title;
            productToUpdate.FullText = p.FullText;
            productToUpdate.OrderNumber = p.OrderNumber;
            productToUpdate.Price = p.Price;
            productToUpdate.ShorText = p.ShorText;
            _context.SaveChanges();
            return RedirectToAction("GetProductList");
        }

        [Authorize]
        public ActionResult GetSectorList()
        {
            cs.Sectors = _context.Sector.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult AddSector()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddSector(HttpPostedFileBase img, Sector s)
        {
            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Sector"), fileName);
                img.SaveAs(path);

                s.Img = fileName;
            }

            _context.Sector.Add(s);
            _context.SaveChanges();
            return RedirectToAction("GetSectorList");
        }
        public ActionResult RemoveSector(int id)
        {
            var sector = _context.Sector.Find(id);

            if (sector != null)
            {
                _context.Sector.Remove(sector);
                _context.SaveChanges();
            }

            return RedirectToAction("GetSectorList");
        }
        [HttpGet]
        public ActionResult UpdateSector(int id)
        {
            var sectorToUpdate = _context.Sector.Find(id);
            if (sectorToUpdate == null)
            {
                return HttpNotFound();
            }

            return View(sectorToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateSector(HttpPostedFileBase img, Sector s, HttpPostedFileBase icon, HttpPostedFileBase detailimg)
        {
            var sectorToUpdate = _context.Sector.Find(s.Id);
            if (sectorToUpdate == null)
            {
                return HttpNotFound();
            }
            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Sector"), fileName);
                img.SaveAs(path);

                sectorToUpdate.Img = fileName;
            }
            if (detailimg != null && detailimg.ContentLength > 0)
            {
                var fileName1 = Path.GetFileName(detailimg.FileName);
                var path1 = Path.Combine(Server.MapPath("~/Images/Sector/Detail"), fileName1);
                detailimg.SaveAs(path1);

                sectorToUpdate.DetailImg = fileName1;

            }
            if (icon != null && icon.ContentLength > 0)
            {
                var fileName2 = Path.GetFileName(icon.FileName);
                var path2 = Path.Combine(Server.MapPath("~/Images/Icon"), fileName2);
                icon.SaveAs(path2);

                sectorToUpdate.Icon = fileName2;
            }


            // Diğer alanları güncelle
            sectorToUpdate.DetailTitle = s.DetailTitle;
            sectorToUpdate.FullText = s.FullText;
            sectorToUpdate.OrderNumber = s.OrderNumber;
            sectorToUpdate.ShortText = s.ShortText;

            _context.SaveChanges();
            return RedirectToAction("GetSectorList");
        }
        [Authorize]
        public ActionResult GetNewsList()
        {
            cs.News = _context.News.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult AddNews()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddNews(HttpPostedFileBase img, News n)
        {
            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/News"), fileName);
                img.SaveAs(path);

                n.Img = fileName;
            }

            _context.News.Add(n);
            _context.SaveChanges();
            return RedirectToAction("GetNewsList");
        }
        public ActionResult RemoveNews(int id)
        {
            var news = _context.News.Find(id);

            if (news != null)
            {
                _context.News.Remove(news);
                _context.SaveChanges();
            }

            return RedirectToAction("GetNewsList");
        }
        [HttpGet]
        public ActionResult UpdateNews(int id)
        {
            var newsToUpdate = _context.News.Find(id);
            if (newsToUpdate == null)
            {
                return HttpNotFound();
            }

            return View(newsToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateNews(HttpPostedFileBase img, News n)
        {
            var newsToUpdate = _context.News.Find(n.Id);
            if (newsToUpdate == null)
            {
                return HttpNotFound();
            }

            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/News"), fileName);
                img.SaveAs(path);

                newsToUpdate.Img = fileName;
            }
            newsToUpdate.Title = n.Title;
            newsToUpdate.Text = n.Text;
            newsToUpdate.OrderNumber = n.OrderNumber;
           
            _context.SaveChanges();
            return RedirectToAction("GetNewsList");
        }
        public ActionResult GetSupportList()
        {
            cs.Supports = _context.Support.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult AddSupport()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddSupport(Support s)
        {


            _context.Support.Add(s);
            _context.SaveChanges();
            return RedirectToAction("GetSupportList");
        }

        public ActionResult RemoveSupport(int id)
        {
            var support = _context.Support.Find(id);

            if (support != null)
            {
                _context.Support.Remove(support);
                _context.SaveChanges();
            }

            return RedirectToAction("GetSupportList");
        }
        [HttpGet]
        public ActionResult UpdateSupport(int id)
        {
            var supportToUpdate = _context.Support.Find(id);
            if (supportToUpdate == null)
            {
                return HttpNotFound();
            }

            return View(supportToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateSupport(Support s)
        {
            var supportToUpdate = _context.Support.Find(s.Id);
            if (supportToUpdate == null)
            {
                return HttpNotFound();
            }


            supportToUpdate.Title = s.Title;
            supportToUpdate.Text = s.Text;
            supportToUpdate.OrderNumber = s.OrderNumber;
            supportToUpdate.PageOrderNumber = s.PageOrderNumber;

            _context.SaveChanges();
            return RedirectToAction("GetSupportList");
        }



    }


}