using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class RegisterController : Controller
    {
        UserDAO userDAO = new UserDAO();

        // GET: Register
        public ActionResult Index()
        {

            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CheckRegister()
        {
            string username = Request["username"];
            string fulname = Request["fullname"];
            string phone= Request["phone"];
            string email = Request["email"];
            string password = Request["password"];
            string re_password= Request["re_password"];
            string messageregister = "";
            User user = userDAO.getUserByUserName(username);
            if (username == "" || fulname==""||phone==""||email==""||password == ""||re_password=="")
            {
                messageregister = "Thông tin không được để trống";
            }
            else if (!password.Equals(re_password))
            {
                messageregister = "Nhập lại mật khẩu không khớp";
            }
            else if (user!=null)
            {
                messageregister = "Tên tài khoản đã tồn tại";
            }
            else
            {
                User userModel = new User();
                userModel.Username =username;
                userModel.Password = re_password;
                userModel.FullName = fulname;
                userModel.Email = email;
                userModel.PhoneNumber = phone;
                userModel.Role_ID = 2;
                userDAO.addUser(userModel);
             
                if (userDAO.getUser(username, password)==null)
                {
                    messageregister = "Đăng ký thất bại, hệ thống đang bị lỗi";
                }
                else
                {
                    messageregister = "Đăng ký tài khoản thành công";
                    Session["UserModel"] = userModel;
                    Session.Timeout = 15;
                }
            }
            Session.Add("messageregister", messageregister);
            return RedirectToAction("Index", "Register");// có thể thay bằng foward
        }
    }
}