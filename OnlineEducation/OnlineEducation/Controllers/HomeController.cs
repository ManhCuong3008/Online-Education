
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
        CourseDAO courseDAO = new CourseDAO();
        // GET: Home
        public ActionResult Index() // đã add layout 
        {
            User user = (User)Session["UserModel"];
            if (user!=null)
            {
                ViewBag.UserModel = user;
            }
            List<Course> ListHL = courseDAO.getListCoursebyCategory(1);
            List<Course> ListFood = courseDAO.getListCoursebyCategory(5);
            ViewBag.ListHL = ListHL;
            ViewBag.ListFood = ListFood;
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