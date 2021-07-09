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
            Teacher teacher = courseDAO.getTeacherByID(Convert.ToInt32(course.Teacher_ID));
            List<Description> descTitle = courseDAO.getListDescbyTitle("Title",CourseID);
            List<Description> listDescLearn = courseDAO.getListDescbyTitle("Learn",CourseID);
            List<Description> listDescIntro = courseDAO.getListDescbyTitle("Intro",CourseID);
            ViewBag.Course = course;
            ViewBag.courseDAO = courseDAO;
            ViewBag.ListChapter = courseDAO.getListChapterByCourseID(CourseID);
            ViewBag.teacher = teacher;
            ViewBag.descTitle = descTitle;
            ViewBag.listDescLearn = listDescLearn;
            ViewBag.listDescIntro = listDescIntro;
            return View();
        }
    }
}