using System.Linq;
using System.Web;
using OnlineEducation.Paging;
using OnlineEduDB;

namespace OnlineEducation.Model
{
    public class DescriptionDAO
    {
        MyDB myDB = new MyDB();
        public void AddDescription(Description obj)
        {
            myDB.Descriptions.Add(obj); // thêm
            myDB.SaveChanges(); // Lưu
        }


    }
}