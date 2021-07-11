using OnlineEducation.Model;
using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class StudyController : Controller
    {
        CourseDAO courseDAO = new CourseDAO();
        // GET: Study
        public ActionResult Index()
        {
            int userid = 0;
            User user = (User)Session["UserModel"];
            if (user != null)
            {
                userid = user.UserID;
                ViewBag.UserModel = user;
            }
            string CourseID = Request["CourseID"];
            MyCourse myCourse = courseDAO.getMyCourse(userid, CourseID);
            string status = "Viewer";
            if (myCourse != null)
            {
                status = "customer";
            }
            
            int videoid = Convert.ToInt32(Request["videoID"]);
            Video beforeVideo = null;
            Video afterVideo = null;
            Course course = courseDAO.getCourseByID(CourseID);
            Video currentVideo = courseDAO.getVideoByID(videoid);
            List<Video> ListVideo = courseDAO.getListVideobyChapterID(currentVideo.Chapter_ID);
            for (int i = 0; i < ListVideo.Count; i++)
            {
                if (ListVideo[0].VideoID == videoid)
                {
                    beforeVideo = ListVideo[0];
                    afterVideo = ListVideo[1];
                    break;
                }
                else if (ListVideo[ListVideo.Count-1].VideoID == videoid)
                {
                    beforeVideo = ListVideo[ListVideo.Count - 2];
                    afterVideo = ListVideo[ListVideo.Count-1];
                    break;
                }
                else
                {
                    if (ListVideo[i].VideoID == videoid)
                    {
                        beforeVideo = ListVideo[i - 1];
                        afterVideo = ListVideo[i + 1];
                        break;
                    }
                }
             
            }

            ViewBag.Video = currentVideo;
            ViewBag.Course = course;
            ViewBag.courseDAO = courseDAO;
            ViewBag.ListChapter = courseDAO.getListChapterByCourseID(CourseID);
            ViewBag.status = status;
            if (beforeVideo != null && afterVideo != null)
            {
                ViewBag.beforeID = beforeVideo.VideoID;
                ViewBag.afterID = afterVideo.VideoID;
            }
            return View();
        }


    }
}