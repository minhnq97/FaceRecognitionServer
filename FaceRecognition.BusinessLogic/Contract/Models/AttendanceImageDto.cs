﻿using DemoFaceRecognition.Model;
using System.Collections.Generic;

namespace FaceRecognition.BusinessLogic.Models
{
    public class AttendanceImageDto
    {
        public int AttendanceImageId { get; set; }
        public string ImagePath { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}