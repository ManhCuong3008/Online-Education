using OnlineEducation.EmailService;
using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class OrderController : Controller
    {
        UserDAO userDAO = new UserDAO();
        CourseDAO courseDAO = new CourseDAO();
        OrderDAO orderDAO = new OrderDAO();
        // GET: Order
        public ActionResult Index()
        {
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }
            else
            {
                return Redirect("/Login");
            }
            string courseID = Request["courseID"];
            Course course = courseDAO.getCourseByID(courseID);
            if (course!=null)
            {
                ViewBag.course = course;
            }
            else
            {
               return Redirect("/Error?message=error");
            }
            ViewBag.email = user.Email;
            ViewBag.phone = user.PhoneNumber;
            return View();
        }

        public ActionResult Verify()
        {
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }
            string courseID = Request["courseID"];
            Course course = courseDAO.getCourseByID(courseID);
            if (course != null)
            {
                ViewBag.course = course;
            }
            else
            {
                return Redirect("/Error?message=error");
            }

            string email = Request["email"];
            string phone = Request["phone"];
            
            if (email==""|| phone=="")
            {
                ViewBag.message = "Thông tin không được để trống";
            }
            else
            {
                ViewBag.email = email;
                ViewBag.phone = phone;
                Order order = new Order();
                order.Course_ID = courseID;
                order.toEmail = email;
                order.toPhone = phone;
                order.User_ID = user.UserID;
                order.Status = "verify";
                courseDAO.AddOrder(order);
                if (courseDAO.getOrder(user.UserID, courseID)!=null)
                {
                    ViewBag.message = "Đăng ký học thành công";
                }
                else
                {
                    ViewBag.message = "Đăng ký không thất bại, hệ thống đang lỗi";
                }
            }

            return View("Index");
        }


        
    }
}