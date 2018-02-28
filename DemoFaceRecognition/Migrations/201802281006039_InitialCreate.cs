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
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceImageId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Room = c.String(nullable: false),
                        AttendanceStatus = c.String(nullable: false),
                        ReportStatus = c.String(nullable: false),
                        SlotId = c.Int(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.String(nullable: false, maxLength: 128),
                        TermId = c.String(nullable: false, maxLength: 128),
                        ClassId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Slots", t => t.SlotId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Terms", t => t.TermId, cascadeDelete: true)
                .Index(t => t.SlotId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.TermId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.String(nullable: false, maxLength: 128),
                        ClassName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        SlotId = c.Int(nullable: false, identity: true),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SlotId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        TermId = c.String(nullable: false, maxLength: 128),
                        TermName = c.String(nullable: false),
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
            DropForeignKey("dbo.Schedules", "TermId", "dbo.Terms");
            DropForeignKey("dbo.Schedules", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Schedules", "SlotId", "dbo.Slots");
            DropForeignKey("dbo.Schedules", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Schedules", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.ScheduleAttendanceImages", "AttendanceImage_AttendanceImageId", "dbo.AttendanceImages");
            DropForeignKey("dbo.ScheduleAttendanceImages", "Schedule_ScheduleId", "dbo.Schedules");
            DropIndex("dbo.ScheduleAttendanceImages", new[] { "AttendanceImage_AttendanceImageId" });
            DropIndex("dbo.ScheduleAttendanceImages", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.Schedules", new[] { "ClassId" });
            DropIndex("dbo.Schedules", new[] { "TermId" });
            DropIndex("dbo.Schedules", new[] { "CourseId" });
            DropIndex("dbo.Schedules", new[] { "TeacherId" });
            DropIndex("dbo.Schedules", new[] { "StudentId" });
            DropIndex("dbo.Schedules", new[] { "SlotId" });
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
