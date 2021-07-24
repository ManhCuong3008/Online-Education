
using OnlineEducation.Model;
using OnlineEducation.Paging;
using OnlineEduDB;
using System;
using System.Collections;
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
        RatingDAO ratingDAO = new RatingDAO();
        // GET: Home
        public ActionResult Index() // đã add layout 
        {
            Session["Url"] = "";
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }

            List<Course> ListHL = courseDAO.getListHL();
            List<Course> ListFood = courseDAO.getListCoursebyCategory(5);
            List<Course> ListFilm = courseDAO.getListCoursebyCategory(3);
            ViewBag.ListHL = ListHL;
            ViewBag.ListFilm = ListFilm;
            ViewBag.ListFood = ListFood;
            ViewBag.ratingDAO = ratingDAO;
            ViewBag.courseDAO = courseDAO;
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("UserModel");
            Session.Remove("Url");
            return Redirect("/home");
        }

        public ActionResult Category()
        {
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }
            int CategoryID = 1;
            if (Request["CaID"] != null)
            {
                CategoryID = Convert.ToInt32(Request["CaID"]);
                ViewBag.CategoryID = CategoryID;
            }
            int index = 1;
            try
            {
                index = Convert.ToInt32(Request["index"]);
            }
            catch (Exception)
            {
                index = 1;
            }
            List<Category> listCategory = courseDAO.getAllCategory();
            if (listCategory != null)
            {
                ViewBag.listCategory = listCategory;
            }
            List<Course> ListCouserCurrent = courseDAO.getListCourseByCategoryId(CategoryID);
            int maxItemOnPage = 6;
            int totalItem = ListCouserCurrent.Count;
            PageRequest page = new PageRequest(index, maxItemOnPage);
            int totalPage = (int)Math.Ceiling((double)totalItem / maxItemOnPage);
            List<Course> ListCourse = new List<Course>();
            ListCourse = courseDAO.getListByOffsetBycategory(page, CategoryID);
            if (ListCourse != null)
            {
                ViewBag.index = index;
                ViewBag.ListCouserCurrent = ListCourse;
            }

            ViewBag.courseDAO = courseDAO;
            ViewBag.totalPage = totalPage;
            return View();
        }


    }
}