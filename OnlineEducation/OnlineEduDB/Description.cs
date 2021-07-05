namespace OnlineEduDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Description")]
    public partial class Description
    {
        [Key]
        public int DescID { get; set; }

        [StringLength(255)]
        public string DescriptonTitle { get; set; }

        [Column("Description")]
        [StringLength(255)]
        public string Description1 { get; set; }

        [StringLength(255)]
        public string ShortTitle { get; set; }

        [StringLength(255)]
        public string ShortDesc { get; set; }

        [Required]
        [StringLength(255)]
        public string Course_ID { get; set; }

        public virtual Course Course { get; set; }
    }
}
