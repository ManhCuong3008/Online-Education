namespace OnlineEduDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public int RatingID { get; set; }

        public int? User_ID { get; set; }

        [StringLength(255)]
        public string Course_ID { get; set; }

        public int? Score { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
