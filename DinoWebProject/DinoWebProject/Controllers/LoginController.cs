using DinoWebProject.Models;
using DinoWebProject.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DinoWebProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {

            DbDinoWebEntities db = new DbDinoWebEntities();
            

            var bilgiler = db.User.FirstOrDefault(x => x.UserName == u.UserName.Trim() &&
                 x.Password == u.Password);
            
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
                Session["UserName"] = bilgiler.UserName;
                return RedirectToAction("GetProductList", "Admin");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Login");
        }
    }

}
