
using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class HomeController : Controller
    {
        UserDAO userDAO = new UserDAO();
        // GET: Home
        public ActionResult Index() // đã add layout 
        {
            User user = (User)Session["UserModel"];
            if (user!=null)
            {
                ViewBag.UserModel = user;
            }
            return View();
        }

        public ActionResult Logout() // đã add layout 
        {
            Session.Remove("UserModel");
            Response.Redirect("/home");
            return View();
        }

        public ActionResult Register()// chưa add layout 
        {
      
            return View();
        }
    }
}