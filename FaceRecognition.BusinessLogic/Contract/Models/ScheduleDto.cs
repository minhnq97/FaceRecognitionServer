using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.BusinessLogic.Models
{
    /// <summary>
    /// Entity representing table Schedules in the database
    /// </summary>
    public class ScheduleDto
    {
        public long ScheduleId { get; set; }
        public string Date { get; set; }
        public int SlotNo { get; set; }
        public string TeacherId { get; set; }
        public string Room { get; set; }
        public string ClassId { get; set; }
        public string AttendanceStatus { get; set; }
        public string ReportStatus { get; set; }
        public string AttendanceSummary { get; set; }
    }
}