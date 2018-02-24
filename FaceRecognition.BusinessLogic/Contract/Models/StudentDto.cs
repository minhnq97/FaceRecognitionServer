using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.Api.Models
{
    public class StudentDto
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}