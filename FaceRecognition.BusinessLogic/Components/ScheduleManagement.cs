using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Interfaces;
using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Components
{
    /// <summary>
    /// Provide methods to handle logics related to Schedule
    /// </summary>
    public class ScheduleManagement : IScheduleManagement, IDisposable
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public void Dispose()
        {
            _context.Dispose();
        }

        public GetTermByUserResponse GetTermByUser(GetTermByUserRequest request)
        {
            GetTermByUserResponse response = new GetTermByUserResponse();
            var termList = new List<TermDto>();
            
            if (request.RoleName.Equals("student")) 
            {
                termList = _context.Schedules.Where(s => s.Student.StudentId == request.UserId).Select(s => new TermDto()
                {
                    TermId = s.Term.TermId,
                    TermName = s.Term.TermName
                }).ToList();
            }
            else if (request.RoleName.Equals("teacher"))
            {
                termList = _context.Schedules.Where(s => s.Teacher.TeacherId == request.UserId).Select(s => new TermDto()
                {
                    TermId = s.Term.TermId,
                    TermName = s.Term.TermName
                }).ToList();
            }
            response.Terms = termList;

            return response;
        }

        public GetCourseByTermResponse GetCourseByTerm(GetCourseByTermRequest request)
        {
            GetCourseByTermResponse response = new GetCourseByTermResponse();
            var courseList = _context.Schedules.Where(s => s.Student.StudentId == request.UserId && s.Term.TermId == request.TermId)
                            .Select(s => new CourseDto()
                            {
                                CourseId = s.Course.CourseId,
                                CourseName = s.Course.CourseName
                            }).ToList();
            response.Courses = courseList;
            return response;
        }
    }
}
