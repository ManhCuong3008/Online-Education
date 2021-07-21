namespace OnlineEduDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int OrderID { get; set; }

        public int User_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Course_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string toEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string toPhone { get; set; }

        [Required]
        [StringLength(255)]
        public string Status { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
