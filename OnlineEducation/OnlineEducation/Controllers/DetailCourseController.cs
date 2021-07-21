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
        RatingDAO ratingDAO = new RatingDAO();
        // GET: DetailCourse
        public ActionResult Index()
        {

            User user = (User)Session["UserModel"];
            int userid = 0;
            if (user != null)
            {
                userid = user.UserID;
                ViewBag.UserModel = user;
            }
            string CourseID = Request["CourseID"];
            MyCourse myCourse = courseDAO.getMyCourse(userid, CourseID);
            string status = "Viewer";
            if (myCourse != null)
            {
                status = "customer";
            }
            Course course = courseDAO.getCourseByID(CourseID);
            if (course == null)
            {
                return Redirect("/Error?message=error");
            }

            if (ratingDAO.getRating(CourseID, userid) == null && userid != 0)
            {
                ViewBag.Ratestatus = "Vote";
            }
            else
            {
                ViewBag.Ratestatus = "";
            }
            Teacher teacher = courseDAO.getTeacherByID(Convert.ToInt32(course.Teacher_ID));
            List<Description> descTitle = courseDAO.getListDescbyTitle("Title", CourseID);
            List<Description> listDescLearn = courseDAO.getListDescbyTitle("Learn", CourseID);
            List<Description> listDescIntro = courseDAO.getListDescbyTitle("Intro", CourseID);
            //lấy ra đánh giá của khóa học
            RatingModel rating = ratingDAO.getRatingModel(CourseID);
            int totalVote = 0;
            double score = 0;
            if (rating != null)
            {
                totalVote = rating.TotalVote;
                score = rating.Score1;
            }
            ViewBag.Course = course;
            ViewBag.courseDAO = courseDAO;
            ViewBag.ListChapter = courseDAO.getListChapterByCourseID(CourseID);
            ViewBag.teacher = teacher;
            ViewBag.descTitle = descTitle;
            ViewBag.listDescLearn = listDescLearn;
            ViewBag.listDescIntro = listDescIntro;
            ViewBag.status = status;
            ViewBag.totalVote = totalVote;
            ViewBag.score = score;
            return View();
        }

        [HttpPost]
        public ActionResult Vote()
        {
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }

            int score = 0;
            if (Request["star1"] != null)
            {
                score = 1;
            }
            else if (Request["star2"] != null)
            {
                score = 2;
            }
            else if (Request["star3"] != null)
            {
                score = 3;
            }
            else if (Request["star4"] != null)
            {
                score = 4;
            }
            else if (Request["star5"] != null)
            {
                score = 5;
            }
            Rating rating = new Rating();
            string courseID = Request["CourseID"];
            rating.User_ID = user.UserID;
            rating.Course_ID = courseID;
            rating.Score = score;
            ratingDAO.AddRating(rating);
            if (ratingDAO.getRating(courseID, user.UserID) != null)
            {
                return Redirect("Index?CourseID=" + courseID + "");
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }
}