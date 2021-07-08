using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class DetailCourseController : Controller
    {
        CourseDAO courseDAO = new CourseDAO();
        // GET: DetailCourse
        public ActionResult Index()
        {
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }
            string CourseID = Request["CourseID"];
            Course course = courseDAO.getCourseByID(CourseID);
            ViewBag.Course = course;
            ViewBag.courseDAO = courseDAO;
            ViewBag.ListChapter = courseDAO.getListChapterByCourseID(CourseID);
            return View();
        }
    }
}