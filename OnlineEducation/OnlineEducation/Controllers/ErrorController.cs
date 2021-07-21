using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            string message = Request["message"];
            if (message== "DataNull")
            {
                ViewBag.message = "Khóa học hiện tại vẫn chưa có dữ liệu";
            }
            else if (message == "SearchError")
            {
                ViewBag.message = "Không tìm thấy khóa học với từ khóa trên";
            }
            else
            {
                ViewBag.message = "ERROR";
            }
            return View();
        }
    }
}