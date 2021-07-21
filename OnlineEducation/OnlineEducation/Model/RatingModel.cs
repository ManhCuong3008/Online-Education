using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Model
{
    public class RatingModel
    {
        string CourseID;
        double Score;
        int totalVote;

         public RatingModel()
        {
    
        }

        public RatingModel(double score, int totalVote)
        {
            Score = score;
            this.totalVote = totalVote;
        }

        public RatingModel(string courseID, double score, int totalVote)
        {
            CourseID = courseID;
            Score = score;
            this.totalVote = totalVote;
        }

        public string CourseID1 { get => CourseID; set => CourseID = value; }
        public double Score1 { get => Score; set => Score = value; }
        public int TotalVote { get => totalVote; set => totalVote = value; }
    }
}