using Facebook;
using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                if (user.Role_ID==1)
                {
                    return RedirectToAction("Index", "Admin"); // điều hướng qua admin
                }
                else
                {
                    try
                    {
                        string url = Session["Url"].ToString();
                        if (url != "")
                        {
                            return Redirect(url);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    
                    return RedirectToAction("Index", "Home");
                }
                
            }
            //Session.Add("messagelogin", messagelogin);
            ViewBag.messagelogin = messagelogin;
            ViewBag.username = username;
            ViewBag.password = password;
            // return RedirectToAction("Index","Login");// có thể thay bằng foward
            return View("Index"); // đây la điều hướng bằng foward
        }


        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            try
            {
                var fb = new FacebookClient();
                dynamic result = fb.Post("oauth/access_token", new
                {
                    client_id = ConfigurationManager.AppSettings["FbAppId"],
                    client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                    redirect_uri = RedirectUri.AbsoluteUri,
                    code = code,
                });

                var access_token = result.access_token;
                if (!string.IsNullOrEmpty(access_token))
                {
                    fb.AccessToken = access_token;
                    dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                    string email = me.email;
                    string username = me.email;
                    string firstname = me.first_name;
                    string middlename = me.middle_name;
                    string lastname = me.last_name;
                    string id = me.id;
                    var user = new User();

                    user.Email = email;
                    user.Username = email;
                    user.FullName = firstname + "" + middlename + " " + lastname;
                    user.Role_ID = 2;
                    user.Password = id;
                    user.PhoneNumber = "";
                    userDAO.addUserFacebook(user);
           
                    if (user != null)
                    {
                        Session["UserModel"] = user;
                        Session.Timeout = 15;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}