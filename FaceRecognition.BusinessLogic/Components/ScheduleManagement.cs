using DemoFaceRecognition.Context;
using FaceRecognition.Api.Models;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Components
{
    public class ScheduleManagement:IScheduleManagement, IDisposable
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public void Dispose()
        {
            _context.Dispose();
        }

        public GetTermByUserResponse GetTermByUser(GetTermByUserRequest request)
        {
            GetTermByUserResponse response = new GetTermByUserResponse();
            var termList = _context.Schedules.Where(s => s.Student.StudentId==request.UserId).Select(s => new TermDto()
            { 
                TermId = s.Term.TermId,
                TermName = s.Term.TermName
            }).ToList();
            response.Terms = termList;
            //var scheduleList = _context.Schedules.Where(s => s.Student.StudentId == request.UserId).Select(s => new ScheduleDto()
            //{
            //    ScheduleId = s.ScheduleId,
            //    Date = s.Date,
            //    Room = s.Room,
            //    AttendanceStatus = s.AttendanceStatus,
            //    ReportStatus = s.ReportStatus,
            //    Slot = s.Slot,
            //    Student = s.Student,
            //    Teacher = s.Teacher,
            //    Course = s.Course,
            //    Term = s.Term,
            //    AttendanceImages = s.AttendanceImages.ToList(),
            //    Class = s.Class
            //}).ToList();
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
