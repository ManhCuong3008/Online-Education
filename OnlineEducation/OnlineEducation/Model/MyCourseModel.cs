using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Model
{
    public class MyCourseModel
    {
        public string CourseID { get; set; }

        public string CourseName { get; set; }

        public int CategoryCourse { get; set; }

        public DateTime CreateDate { get; set; }

        public int? Teacher_ID { get; set; }

        public string Active_ID { get; set; }

        public string Price { get; set; }

        public string Image_url { get; set; }

    }
}