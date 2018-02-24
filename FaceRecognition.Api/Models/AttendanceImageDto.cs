using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.Api.Models
{
    public class AttendanceImageDto
    {
        public int AttendanceImageId { get; set; }
        public string ImagePath { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}