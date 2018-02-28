using DemoFaceRecognition.Model;
using System.Collections.Generic;

namespace FaceRecognition.BusinessLogic.Models
{
    public class AttendanceImageDto
    {
        /// <summary>
        /// Entity representing table AttendanceImages in the database
        /// </summary>
        public int AttendanceImageId { get; set; }
        public string ImagePath { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}