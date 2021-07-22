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
    public class AdminController : Controller
    {
        UserDAO userDAO = new UserDAO();
        CourseDAO courseDAO = new CourseDAO();
        OrderDAO orderDAO = new OrderDAO();
        // GET: Admin
        public ActionResult Index()
        {
            User UserModel = (User)Session["UserModel"];
            if (UserModel != null)
            {
                if (UserModel.Role_ID != 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.UserModel = UserModel;
                }
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
            if (password == "" || fullname == "" || email == "" || phone == "")
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

        [HttpPost]
        public ActionResult SendGmail()
        {
            int orderID = Convert.ToInt32(Request["OrderID"]);
            Order order = orderDAO.getOrderByID(orderID);
            Course course = courseDAO.getCourseByID(order.Course_ID);

            string smtpUserName = "onlineeducshap@gmail.com";
            string smtpPassword = "vietnam@123";
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587; //587,25

            string emailTo = order.toEmail;
            string subject = "Bạn vừa nhận được liên hê từ OnlineEdu: Xác nhận mã kích hoạt khóa học";
            string body = System.IO.File.ReadAllText(Server.MapPath("~/Content/Templete/Active.html"));
            body = body.Replace("{{ActiveCode}}", course.Active_ID);
            body = body.Replace("{{CourseName}}", course.CourseName);

            EmailRequest service = new EmailRequest();
            bool result = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);
            if (result == true)
            {
                orderDAO.updateOrder(orderID, "paymented");
                return Redirect("/Admin/Manager");
            }
            else
            {
                return Redirect("/Error");
            }
        }


    }
}