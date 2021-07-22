using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OnlineEducation.Controllers
{
    public class AddCourseController : Controller
    {

        TeacherDAO teacherDao = new TeacherDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        CourseDAO courseDAO = new CourseDAO();
        // GET: AddCourse
        public ActionResult Index()
        {

            User UserModel = (User)Session["UserModel"];
            if (UserModel != null)
            {
                ViewBag.UserModel = UserModel;
            }
            List<Teacher> listTeacher = teacherDao.getAllTeacher();
            List<Category> listCategory = categoryDAO.getAllCategory();
            ViewBag.listTeacher = listTeacher;
            ViewBag.listCategory = listCategory;
            return View();
        }


        [HttpPost]
        public ActionResult addcourse()
        {
            string teacher = Request["teacher"];
            string category = Request["category"];
            string coursename = Request["coursename"];
            string courseid = Request["courseid"];
            string activecode = Request["activecode"];
            string price = Request["price"];
            string image = Request["image"];

            string message = "";
            if (coursename == "" || courseid == "" || activecode == "" || price == "" || image == "")
            {
                message = "Thông tin không được để trống";
            }
            else
            {
                Course course = new Course();
                course.CourseID = courseid;
                course.CourseName = coursename;
                course.CategoryCourse = Convert.ToInt32(category);
                course.Teacher_ID = Convert.ToInt32(teacher);
                course.Price = price;
                course.Image_url = image;
                courseDAO.AddCourse(course);
                message = "Cập nhật thành công";
            }
            List<Teacher> listTeacher = teacherDao.getAllTeacher();
            List<Category> listCategory = categoryDAO.getAllCategory();
            ViewBag.listTeacher = listTeacher;
            ViewBag.listCategory = listCategory;
            ViewBag.message = message;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Desc()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Chapter()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Video()
        {
            return View();
        }


    }
}