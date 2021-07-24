using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using OnlineEducation.Paging;
using OnlineEduDB;

namespace OnlineEducation.Model
{
    public class ChapterDAO
    {
        MyDB myDB = new MyDB();
        public void AddChapter(Chapter obj)
        {
            myDB.Chapters.Add(obj); // thêm
            myDB.SaveChanges(); // Lưu
        }

    }


}