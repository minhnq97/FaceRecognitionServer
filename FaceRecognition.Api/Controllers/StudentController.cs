using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaceRecognition.Api.Controllers
{
    public class StudentsController : ApiController
    {
        public FaceRecognitionContext _context = new FaceRecognitionContext();
        

        public IEnumerable<StudentDto> GetAllStudents()
        {
            return _context.Students.Select(s => new StudentDto()
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                Image = s.Image
            });
        }
    }
}
