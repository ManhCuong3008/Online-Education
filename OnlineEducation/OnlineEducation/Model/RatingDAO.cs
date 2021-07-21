using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using OnlineEduDB;

namespace OnlineEducation.Model
{
    public class RatingDAO
    {
        MyDB myDB = new MyDB();

        public List<Rating> getListRatingByCourseID(string courseID)
        {
            return myDB.Ratings.Where(r => r.Course_ID == courseID).ToList();
        }
        public Rating getRating(string courseID,int userID)
        {
            return myDB.Ratings.Where(r => r.Course_ID == courseID&&r.User_ID==userID).FirstOrDefault();
        }
        public int getAvgScoreRating(string courseID)
        {
            List<Rating> list = getListRatingByCourseID(courseID);
            double sum = 0;
            foreach (var item in list)
            {
                sum = sum + Convert.ToDouble(item.Score);
            }
            sum = (double)sum / list.Count;
            return (int)Math.Ceiling(sum);
        }

        public RatingModel getRatingModel(string courseID)
        {
            try
            {
                RatingModel ratingModel = new RatingModel();
                ratingModel.CourseID1 = courseID;
                ratingModel.Score1 = (double)(from r in myDB.Ratings where r.Course_ID == courseID select r.Score).Average();
                ratingModel.TotalVote = Convert.ToInt32((from r in myDB.Ratings where r.Course_ID == courseID select r.Score).Count());
                return ratingModel;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void AddRating(Rating obj)
        {
            myDB.Ratings.Add(obj); // thêm
            myDB.SaveChanges();
        }

    }
}