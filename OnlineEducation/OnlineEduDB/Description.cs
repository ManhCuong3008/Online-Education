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

        [Column("Description", TypeName = "ntext")]
        public string Description1 { get; set; }

        [Required]
        [StringLength(255)]
        public string Course_ID { get; set; }

        public virtual Course Course { get; set; }
    }
}
