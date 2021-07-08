using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineEduDB
{
    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<Active> Actives { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<MyCourse> MyCourses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Active>()
                .Property(e => e.ActiveID)
                .IsUnicode(false);

            modelBuilder.Entity<Active>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Active>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Active)
                .HasForeignKey(e => e.Active_ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryCourse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chapter>()
                .Property(e => e.Course_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Chapter>()
                .HasMany(e => e.Videos)
                .WithRequired(e => e.Chapter)
                .HasForeignKey(e => e.Chapter_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Active_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Chapters)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.Course_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Descriptions)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.Course_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.MyCourses)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.Course_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Description>()
                .Property(e => e.DescriptonTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Description>()
                .Property(e => e.Course_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MyCourse>()
                .Property(e => e.Course_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.Role_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Age)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Url_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Teacher)
                .HasForeignKey(e => e.Teacher_ID);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Image_url)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MyCourses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.Video_url)
                .IsUnicode(false);
        }
    }
}
