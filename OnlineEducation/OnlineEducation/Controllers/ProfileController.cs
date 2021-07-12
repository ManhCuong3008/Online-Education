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
            ViewBag.listMyCourse = listMyCourse;
            ViewBag.ListCourseOffer = courseDAO.getListCourseOffer(user.UserID);
            ViewBag.videoID = videoID;
            return View();
        }

        public ActionResult ActiveCourse()
        {
            return View();
        }

    }
}