namespace DemoFaceRecognition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceImages",
                c => new
                    {
                        AttendanceImageId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.AttendanceImageId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Room = c.String(),
                        AttendanceStatus = c.String(),
                        ReportStatus = c.String(),
                        Class_ClassId = c.String(maxLength: 128),
                        Course_CourseId = c.String(maxLength: 128),
                        Slot_SlotId = c.Int(),
                        Student_StudentId = c.String(maxLength: 128),
                        Teacher_TeacherId = c.String(maxLength: 128),
                        Term_TermId = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Slots", t => t.Slot_SlotId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId)
                .ForeignKey("dbo.Terms", t => t.Term_TermId)
                .Index(t => t.Class_ClassId)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Slot_SlotId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.Term_TermId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.String(nullable: false, maxLength: 128),
                        ClassName = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        SlotId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SlotId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Email = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        TermId = c.Int(nullable: false, identity: true),
                        TermName = c.String(),
                    })
                .PrimaryKey(t => t.TermId);
            
            CreateTable(
                "dbo.ScheduleAttendanceImages",
                c => new
                    {
                        Schedule_ScheduleId = c.Int(nullable: false),
                        AttendanceImage_AttendanceImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Schedule_ScheduleId, t.AttendanceImage_AttendanceImageId })
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.AttendanceImages", t => t.AttendanceImage_AttendanceImageId, cascadeDelete: true)
                .Index(t => t.Schedule_ScheduleId)
                .Index(t => t.AttendanceImage_AttendanceImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "Term_TermId", "dbo.Terms");
            DropForeignKey("dbo.Schedules", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Schedules", "Slot_SlotId", "dbo.Slots");
            DropForeignKey("dbo.Schedules", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Schedules", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.ScheduleAttendanceImages", "AttendanceImage_AttendanceImageId", "dbo.AttendanceImages");
            DropForeignKey("dbo.ScheduleAttendanceImages", "Schedule_ScheduleId", "dbo.Schedules");
            DropIndex("dbo.ScheduleAttendanceImages", new[] { "AttendanceImage_AttendanceImageId" });
            DropIndex("dbo.ScheduleAttendanceImages", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.Schedules", new[] { "Term_TermId" });
            DropIndex("dbo.Schedules", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Schedules", new[] { "Student_StudentId" });
            DropIndex("dbo.Schedules", new[] { "Slot_SlotId" });
            DropIndex("dbo.Schedules", new[] { "Course_CourseId" });
            DropIndex("dbo.Schedules", new[] { "Class_ClassId" });
            DropTable("dbo.ScheduleAttendanceImages");
            DropTable("dbo.Terms");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Slots");
            DropTable("dbo.Courses");
            DropTable("dbo.Classes");
            DropTable("dbo.Schedules");
            DropTable("dbo.AttendanceImages");
        }
    }
}
