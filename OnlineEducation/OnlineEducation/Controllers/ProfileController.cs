using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class ProfileController : Controller
    {
        UserDAO userDAO = new UserDAO();
        CourseDAO courseDAO = new CourseDAO();
        OrderDAO orderDAO = new OrderDAO();
        // GET: Profile
        public ActionResult Index()
        {
            User UserModel = (User)Session["UserModel"];
            if (UserModel != null)
            {
                ViewBag.UserModel = UserModel;
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            User UserModel = (User)Session["UserModel"];
            if (UserModel != null)
            {
                ViewBag.UserModel = UserModel;
            }
            string password = Request["password"];
            string fullname = Request["fullname"];
            string email = Request["email"];
            string phone = Request["phone"];
            UserModel.Password = password;
            UserModel.FullName = fullname;
            UserModel.Email = email;
            UserModel.PhoneNumber = phone;
            string message = "";
            if (password==""||fullname==""||email==""||phone=="")
            {
                message = "Thông tin không được để trống";
            }
            else
            {
                userDAO.updateInforUser(UserModel);
                message = "Cập nhật thành công";
            }
            ViewBag.message = message;
            Session["UserModel"] = UserModel;
            return View("Index");
        }

        public ActionResult MyCourse()
        {
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }
            int videoID = 0;
            ViewBag.courseDao = courseDAO;
            List<MyCourseModel> listMyCourse = courseDAO.getListMyCourseByUserID(user.UserID);
            List<Course> ListCourseOffer = courseDAO.getListCourseOffer(user.UserID);
            if (listMyCourse!=null)
            {
                ViewBag.listMyCourse = listMyCourse;
            }
            if (ListCourseOffer!=null)
            {
                ViewBag.ListCourseOffer = ListCourseOffer;
            }
            ViewBag.videoID = videoID;
            return View();
        }

        public ActionResult ActiveCourse()
        {
            User UserModel = (User)Session["UserModel"];
            if (UserModel != null)
            {
                ViewBag.UserModel = UserModel;
            }
            string message =  Request["message"];
            if (message != null)
            {
                if (message != "fail"&& message != "actived")
                {
                    Course course = courseDAO.getCourseByID(message);
                    ViewBag.message = "Kích hoạt thành công khóa học: " + course.CourseName;
                }
                else if (message == "actived")
                {
                    ViewBag.message = "Khóa học này đã được kích hoạt rồi";
                }
                else
                {
                    ViewBag.message = "Kích hoạt thất bại, nhập sai mã khóa học";
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult VerifyActive()
        {

            User user = (User)Session["UserModel"];
            int userid = 0;
            if (user != null)
            {
                ViewBag.UserModel = user;
                userid = user.UserID;
            }
            else
            {
               return Redirect("/login");
            }
            string codeActive = Request["codeActive"];
            
            Course coursePayment = orderDAO.getCourseByActive(codeActive);
            if (coursePayment != null)
            {
                MyCourse myCourse = new MyCourse();
                myCourse.Course_ID = coursePayment.CourseID;
                myCourse.User_ID = userid;
              
                if (courseDAO.getMyCourse(userid, coursePayment.CourseID)!=null)
                {
                    return Redirect("/Profile/ActiveCourse?message=actived");
                }
                else
                {
                    courseDAO.AddMycourse(myCourse);
                    return Redirect("/Profile/ActiveCourse?message=" + coursePayment.CourseID + "");
                }
            }
         return  Redirect("/Profile/ActiveCourse?message=fail");
        }


    }
}