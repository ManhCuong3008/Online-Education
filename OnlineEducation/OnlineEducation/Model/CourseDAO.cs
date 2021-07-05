using System;
using System.Collections.Generic;
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
    }
}