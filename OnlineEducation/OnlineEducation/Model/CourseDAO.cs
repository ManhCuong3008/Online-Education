using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using OnlineEducation.Paging;
using OnlineEduDB;

namespace OnlineEducation.Model
{
    public class CourseDAO
    {
        MyDB myDB = new MyDB();
        public List<Course> getListCourseByName(string courseName)
        {
            return myDB.Courses.Where(c => c.CourseName.Contains(courseName)).ToList();
        }

        public List<Course> getListByOffset(PageRequest page, string courseName)
        {
            return myDB.Courses.Where(c => c.CourseName.Contains(courseName)).OrderBy(c => c.CourseName).Skip(page.getOffset()).Take(page.getLimit()).ToList();
        }

        public MyCourse getMyCourse(int userid, string courseID)
        {
            return myDB.MyCourses.Where(mc => mc.User_ID == userid && mc.Course_ID == courseID).FirstOrDefault();
        }

        public List<Course> getListAscByOffset(PageRequest page, string courseName)
        {
            return myDB.Courses.Where(c => c.CourseName.Contains(courseName)).OrderBy(c => c.Price).Skip(page.getOffset()).Take(page.getLimit()).ToList();
        }
        public List<Course> getListByOffsetOrderByDate(PageRequest page, string courseName)
        {
            return myDB.Courses.Where(c => c.CourseName.Contains(courseName)).OrderByDescending(c => c.CreateDate).Skip(page.getOffset()).Take(page.getLimit()).ToList();
        }
        public List<Course> getListDescByOffset(PageRequest page, string courseName)
        {
            return myDB.Courses.Where(c => c.CourseName.Contains(courseName)).OrderByDescending(c => c.Price).Skip(page.getOffset()).Take(page.getLimit()).ToList();
        }

        public List<Course> getListCoursebyCategory(int category)
        {
            return myDB.Courses.Where(c => c.CategoryCourse == category).OrderBy(c => SqlFunctions.Checksum(Guid.NewGuid())).Take(6).ToList();
        }

        public Course getCourseByID(string id)
        {
            return myDB.Courses.Where(c => c.CourseID == id).FirstOrDefault();
        }
        public Teacher getTeacherByID(int teacherid)
        {
            return myDB.Teachers.Where(t => t.TeacherID == teacherid).FirstOrDefault();
        }


        public List<Chapter> getListChapterByCourseID(string courseID)
        {
            return myDB.Chapters.Where(c => c.Course_ID == courseID).ToList();
        }

        public List<Video> getListVideobyChapterID(int chapterid)
        {
            return myDB.Videos.Where(v => v.Chapter_ID == chapterid).ToList();
        }

        public Video getVideoByID(int id)
        {
            return myDB.Videos.Where(v => v.VideoID == id).FirstOrDefault();
        }

        public Description getDescByTitle(string title, string courseID)
        {
            return myDB.Descriptions.Where(d => d.DescriptonTitle == title && d.Course_ID == courseID).FirstOrDefault();
        }

        public List<Description> getListDescbyTitle(string title, string courseID)
        {
            return myDB.Descriptions.Where(d => d.DescriptonTitle == title && d.Course_ID == courseID).ToList();
        }


        public List<MyCourseModel> getListMyCourseByUserID(int userid)
        {
            var model = from c in myDB.Courses
                        join mc in myDB.MyCourses
                        on c.CourseID equals mc.Course_ID
                        where mc.User_ID == userid
                        select new MyCourseModel
                        {
                            CourseID = c.CourseID,
                            CourseName = c.CourseName,
                            CategoryCourse = c.CategoryCourse,
                            CreateDate = c.CreateDate,
                            Teacher_ID = c.Teacher_ID,
                            Active_ID = c.Active_ID,
                            Price = c.Price,
                            Image_url = c.Image_url
                        };
            return model.ToList();
        }


        //public int getVideoIdMyCourse(string courseId)
        //{
        //    Chapter chapter1 = getListChapterByCourseID(courseId)[0];
        //    Video video = getListVideobyChapterID(chapter1.ChapterID)[0];
        //    return Convert.ToInt32(video.VideoID);
        //}

        public List<Course> getListCourseOffer(int userid)
        {
            var listOffer = myDB.Courses.SqlQuery(
                "  SELECT * FROM Course AS c JOIN (SELECT CourseID FROM Course EXCEPT SELECT mc.Course_ID  FROM MyCourse AS mc WHERE mc.User_ID ='"+ userid + "') AS b ON b.CourseID = c.CourseID ORDER BY CHECKSUM(NEWID())"
                ).Take(3).ToList();
            return listOffer;
        }

        public int getVideoIdOneByCourseID(string courseId) { 
            var Video1 = myDB.Videos.SqlQuery(
                "SELECT * FROM dbo.Video AS v JOIN(SELECT TOP(1) ChapterID FROM dbo.Chapter WHERE Course_ID = '"+courseId+"') AS c ON c.ChapterID = v.Chapter_ID ORDER BY v.VideoID ASC"
                ).FirstOrDefault();
            if (Video1==null)
            {
                return 0;
            }
            else
            {
                return Video1.VideoID;
            }
        }

        public void AddCourse(Course obj)
        {
            myDB.Courses.Add(obj); // thêm
            myDB.SaveChanges(); // Lưu
        }

        public void AddOrder(Order obj)
        {
            myDB.Orders.Add(obj); // thêm
            myDB.SaveChanges(); // Lưu
        }
        public void AddMycourse(MyCourse obj)
        {
            myDB.MyCourses.Add(obj); // thêm
            myDB.SaveChanges(); // Lưu
        }

        public Order getOrder(int userid, string courseID)
        {
            return myDB.Orders.Where(o => o.User_ID ==userid&&o.Course_ID==courseID).FirstOrDefault();
        }


    }
}