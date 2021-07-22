using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using OnlineEducation.Paging;
using OnlineEduDB;

namespace OnlineEducation.Model
{
    public class CategoryDAO
    {
        MyDB myDB = new MyDB();
        public List<Category> getAllCategory()
        {
            return myDB.Categories.ToList();
        }
    }
}