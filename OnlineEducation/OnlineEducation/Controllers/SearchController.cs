﻿using OnlineEducation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineEduDB;
using OnlineEducation.Paging;

namespace OnlineEducation.Controllers
{
    public class SearchController : Controller
    {
        CourseDAO courseDAO = new CourseDAO();
        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                ViewBag.UserModel = user;
            }

            string sortBy = Request["sortBy"];
            string textSearch = Request["txtSearch"];
            int index = 1;
            try
            {
                index = Convert.ToInt32(Request["index"]);
            }
            catch (Exception)
            {
                index = 1;
            }
            List<Course> List = courseDAO.getListCourseByName(textSearch);
            int maxItemOnPage = 6;
            int totalItem = List.Count;
            PageRequest page = new PageRequest(index, maxItemOnPage);
            int totalPage = (int)Math.Ceiling((double)totalItem / maxItemOnPage);
            List<Course> ListCourse = new List<Course>();
            if (textSearch=="")
            {
                return Redirect("/Error?message=SearchError");
            }
            if (sortBy== "ascPrice")
            {
                ListCourse = courseDAO.getListAscByOffset(page, textSearch);
            }
            else if (sortBy == "descPrice")
            {
                ListCourse = courseDAO.getListDescByOffset(page, textSearch);
            }
            else if (sortBy == "createDate")
            {
                ListCourse = courseDAO.getListByOffsetOrderByDate(page, textSearch);
            }
            else
            {
                ListCourse = courseDAO.getListByOffset(page, textSearch);
            }
            ViewBag.index = index;
            ViewBag.ListCourse = ListCourse;
            ViewBag.txtSearch = textSearch;
            ViewBag.totalPage = totalPage;
            ViewBag.totalItem = totalItem;
            ViewBag.courseDAO = courseDAO;
            return View();
        }
    }
}