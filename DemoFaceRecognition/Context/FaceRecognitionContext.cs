

namespace DemoFaceRecognition.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using DemoFaceRecognition.Model;
    public class FaceRecognitionContext : DbContext
    {
        public FaceRecognitionContext()
        {
            this.Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new CreateDatabaseIfNotExists<FaceRecognitionContext>());
        }
        public DbSet<AttendanceImage> AttendanceImages { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
