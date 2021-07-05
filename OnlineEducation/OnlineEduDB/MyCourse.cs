namespace OnlineEduDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyCourse")]
    public partial class MyCourse
    {
        public int ID { get; set; }

        public int User_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Course_ID { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
