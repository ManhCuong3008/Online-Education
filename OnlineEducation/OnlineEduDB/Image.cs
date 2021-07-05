namespace OnlineEduDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int ImageID { get; set; }

        public int? ImageName { get; set; }

        [StringLength(255)]
        public string Image_url { get; set; }

        [Required]
        [StringLength(255)]
        public string Course_ID { get; set; }

        public virtual Course Course { get; set; }
    }
}
