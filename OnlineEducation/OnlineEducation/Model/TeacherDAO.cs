using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using OnlineEducation.Paging;
using OnlineEduDB;

namespace OnlineEducation.Model
{
    public class TeacherDAO
    {
        MyDB myDB = new MyDB();
        public List<Teacher> getAllTeacher()
        {
            return myDB.Teachers.ToList();
        }
    }
}