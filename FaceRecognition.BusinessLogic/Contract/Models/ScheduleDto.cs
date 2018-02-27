using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.BusinessLogic.Models
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public DateTime Date { get; set; }
        public string Room { get; set; }
        public string AttendanceStatus { get; set; }
        public string ReportStatus { get; set; }

        public Slot Slot { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public Term Term { get; set; }
        public List<AttendanceImage> AttendanceImages { get; set; }
        public Class Class { get; set; }
    }
}