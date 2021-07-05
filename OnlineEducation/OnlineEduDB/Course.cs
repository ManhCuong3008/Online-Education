namespace OnlineEduDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Chapters = new HashSet<Chapter>();
            Descriptions = new HashSet<Description>();
            MyCourses = new HashSet<MyCourse>();
        }

        [StringLength(255)]
        public string CourseID { get; set; }

        [Required]
        [StringLength(255)]
        public string CourseName { get; set; }

        public int CategoryCourse { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        public int? Teacher_ID { get; set; }

        [StringLength(255)]
        public string Active_ID { get; set; }

        [StringLength(100)]
        public string Price { get; set; }

        [StringLength(100)]
        public string Image_url { get; set; }

        public virtual Active Active { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chapter> Chapters { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Description> Descriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyCourse> MyCourses { get; set; }
    }
}
