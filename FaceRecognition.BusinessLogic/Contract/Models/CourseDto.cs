using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.BusinessLogic.Models
{
    /// <summary>
    /// Entity representing table Courses in the database
    /// </summary>
    public class CourseDto
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
}