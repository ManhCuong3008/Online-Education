using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class AdminController : Controller
    {
        UserDAO userDAO = new UserDAO();
        CourseDAO courseDAO = new CourseDAO();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Manager()
        {
            OrderDAO orderDAO = new OrderDAO();
            List<Order> ListOrder = orderDAO.getListOrder();
            ViewBag.ListOrder = ListOrder;
            ViewBag.courseDAO = courseDAO;
            ViewBag.userDAO = userDAO;
            return View();
        }
        
   

    }
}