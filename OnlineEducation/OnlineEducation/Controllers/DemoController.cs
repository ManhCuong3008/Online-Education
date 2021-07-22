using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Generate()
        {
            int totalChapter = Convert.ToInt32(Request["totalChapter"]);
            ViewBag.totalChapter = totalChapter;
            return View("Index");
        }




    }
}