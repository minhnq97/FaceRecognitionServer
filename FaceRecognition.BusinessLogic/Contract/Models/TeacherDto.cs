using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.BusinessLogic.Models
{
    /// <summary>
    /// Entity representing table Teachers in the database
    /// </summary>
    public class TeacherDto
    {
        public string TeacherId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}