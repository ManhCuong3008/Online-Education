using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class LoginController : Controller
    {
        UserDAO userDAO = new UserDAO();

        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            string username = Request["username"];
            string password = Request["password"];
            string messagelogin = "";
            User user = userDAO.getUser(username, password);
            if (username == "" || password == "")
            {
                messagelogin = "Tài khoản mật khẩu không được để trống";
            }
            else if (user == null)
            {
                messagelogin = "Tên đăng nhập hoặc mật khẩu sai";
            }
            else
            {
                messagelogin = "";
                Session["UserModel"] = user;
                Session.Timeout = 15;
                return RedirectToAction("Index","Home");
            }
            Session.Add("messagelogin", messagelogin);
            return RedirectToAction("Index","Login");// có thể thay bằng foward
        }
    }
}