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
            string message = "";
            User user = userDAO.getUser(username, password);
            if (username == "" || password == "")
            {
                message = "Tài khoản mật khẩu không được để trống";
            }
            else if (user == null)
            {
                message = "Tên đăng nhập hoặc mật khẩu sai";
            }
            else
            {
                Session["UserModel"] = user;
                Session.Timeout = 15;
                return RedirectToAction("Index","Home");
            }
            Session.Add("message", message);
            return RedirectToAction("Index","Login");// có thể thay bằng foward
        }
    }
}