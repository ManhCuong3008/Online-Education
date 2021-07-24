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
        DescriptionDAO descriptionDAO = new DescriptionDAO();
        ChapterDAO chapterDAO = new ChapterDAO();
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
                course.CreateDate = DateTime.Now;
                course.CourseName = coursename;
                course.CategoryCourse = Convert.ToInt32(category);
                course.Teacher_ID = Convert.ToInt32(teacher);
                course.Price = price;
                course.Active_ID = activecode;
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

        [HttpPost]
        public ActionResult GenDesc()
        {
            int totalLearn = Convert.ToInt32(Request["totallearn"]);
            int totalintro = Convert.ToInt32(Request["totalintro"]);
            ViewBag.totallearn = totalLearn;
            ViewBag.totalintro = totalintro;
            return View("Desc");
        }

        [HttpPost]
        public ActionResult AddDesc()
        {

            int totalLearn = Convert.ToInt32(Request["totallearn"]);
            int totalintro = Convert.ToInt32(Request["totalintro"]);

            string courseid = Request["courseid"].ToString();
            string message = "";
            for (int i = 1; i <= totalLearn; i++)
            {

                string learn = Request["learn" + i].ToString();
                if (learn == null)
                {
                    message = "Thông tin không được để trống";
                }
                else
                {
                    Description description = new Description();
                    description.DescriptonTitle = "Learn";
                    description.Description1 = learn;
                    description.Course_ID = courseid;
                    descriptionDAO.AddDescription(description);
                }
            }

            for (int i = 1; i <= totalintro; i++)
            {
                string intro = Request["intro" + i].ToString();
                if (intro == null)
                {
                    message = "Thông tin không được để trống";
                }
                else
                {
                    Description description = new Description();
                    description.DescriptonTitle = "Intro";
                    description.Description1 = intro;
                    description.Course_ID = courseid;
                    descriptionDAO.AddDescription(description);
                    message = "Cập nhật thành công";
                }
            }
            ViewBag.message = message;
            return View("Desc");
        }

        [HttpGet]
        public ActionResult Chapter()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GenChap()
        {
            int totalchap = Convert.ToInt32(Request["totalchap"]);
            ViewBag.totalchap = totalchap;
            return View("Chapter");
        }

        [HttpPost]
        public ActionResult AddChap()
        {

            int totalchap = Convert.ToInt32(Request["totalchap"]);

            string courseid = Request["courseid"].ToString();
            string message = "";
            for (int i = 1; i <= totalchap; i++)
            {

                string chap = Request["chapter" + i].ToString();
                if (chap == null)
                {
                    message = "Thông tin không được để trống";
                }
                else
                {
                    Chapter chapter = new Chapter();
                    chapter.Course_ID = courseid;
                    chapter.Name = "Chương " + i;
                    chapter.Title = chap;
                    chapterDAO.AddChapter(chapter);
                    message = "Cập nhật thành công";
                }
            }
            ViewBag.message = message;
            return View("Chapter");

        }

        [HttpGet]
        public ActionResult Video()
        {
            return View();
        }




    }
}