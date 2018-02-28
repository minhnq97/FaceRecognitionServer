using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Response
{
    /// <summary>
    /// Response Model when returning a list of courses response to client
    /// </summary>
    public class GetCourseByTermResponse
    {
        public List<CourseDto> Courses { get; set; }
    }
}
