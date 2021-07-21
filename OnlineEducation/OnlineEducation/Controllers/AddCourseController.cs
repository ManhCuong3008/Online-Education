using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class AddCourseController : Controller
    {
        // GET: AddCourse
        public ActionResult Index()
        {
            return View();
        } 

        [HttpGet]
        public ActionResult Desc()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Chapter()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Video()
        {
            return View();
        }


    }
}