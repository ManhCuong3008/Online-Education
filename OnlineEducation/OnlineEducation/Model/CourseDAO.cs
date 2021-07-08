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
       public List<Course>  getListCourseByName(string courseName)
        {
            return myDB.Courses.Where(c=> c.CourseName.Contains(courseName)).ToList();
        }

        public List<Course> getListByOffset( PageRequest page, string courseName)
        {
            return myDB.Courses.Where(c => c.CourseName.Contains(courseName)).OrderBy(c => c.CourseName).Skip(page.getOffset()).Take(page.getLimit()).ToList();
        }

        public List<Course> getListCoursebyCategory(int  category)
        {
            return myDB.Courses.Where(c => c.CategoryCourse == category).OrderBy(c => SqlFunctions.Checksum(Guid.NewGuid())).Take(6).ToList();
        }

        public Course getCourseByID(string id)
        {
            return myDB.Courses.Where(c => c.CourseID == id).FirstOrDefault();
        }

        public List<Chapter> getListChapterByCourseID(string courseID)
        {
            return myDB.Chapters.Where(c => c.Course_ID == courseID).ToList();
        }

        public List<Video> getListVideobyChapterID(int chapterid)
        {
            return myDB.Videos.Where(v => v.Chapter_ID == chapterid).ToList();
        }

    }
}