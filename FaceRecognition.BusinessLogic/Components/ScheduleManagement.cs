using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Interfaces;
using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
                termList = _context.Schedules.Where(s => s.Student.StudentId == request.UserId)
                            .Select(s => new { s.Term.TermId, s.Term.TermName })
                            .GroupBy(g => g.TermId)
                            .Select(s => new TermDto()
                            {
                                TermId = s.FirstOrDefault().TermId,
                                TermName = s.FirstOrDefault().TermName
                            }).ToList();
            }
            else if (request.RoleName.Equals("teacher"))
            {
                termList = _context.Schedules.Where(s => s.Teacher.TeacherId == request.UserId)
                            .Select(s => new { s.Term.TermId, s.Term.TermName })
                            .GroupBy(g => g.TermId)
                            .Select(s => new TermDto()
                            {
                                TermId = s.FirstOrDefault().TermId,
                                TermName = s.FirstOrDefault().TermName
                            }).ToList();
            }
            response.Terms = termList;

            return response;
        }

        public GetCourseByTermResponse GetCourseByTerm(GetCourseByTermRequest request)
        {
            GetCourseByTermResponse response = new GetCourseByTermResponse();
            var courseList = new List<CourseDto>();
            if (request.RoleName.Equals("student"))
            {
                courseList = _context.Schedules.Where(s => s.Student.StudentId == request.UserId && s.Term.TermId == request.TermId)
                            .Select(c => new { c.Course.CourseId, c.Course.CourseName })
                            .GroupBy(g => new { g.CourseId })
                            .Select(s => new CourseDto()
                            {
                                CourseId = s.FirstOrDefault().CourseId,
                                CourseName = s.FirstOrDefault().CourseName
                            }).ToList();
            }
            else if (request.RoleName.Equals("teacher"))
            {
                courseList = _context.Schedules.Where(s => s.Teacher.TeacherId == request.UserId && s.Term.TermId == request.TermId)
                            .Select(c => new { c.Course.CourseId, c.Course.CourseName })
                            .GroupBy(g => new { g.CourseId })
                            .Select(s => new CourseDto()
                            {
                                CourseId = s.FirstOrDefault().CourseId,
                                CourseName = s.FirstOrDefault().CourseName
                            }).ToList();
            }
            response.Courses = courseList;
            return response;
        }

        public GetScheduleByUserResponse GetScheduleByUser(GetScheduleByUserRequest request)
        {
            GetScheduleByUserResponse response = new GetScheduleByUserResponse();
            var scheduleList = new List<ScheduleDto>();

            if (request.RoleName.Equals("student"))
            {
                scheduleList = _context.Schedules.Where(s => s.Student.StudentId == request.UserId && s.TermId == request.TermId && s.CourseId == request.CourseId)
                                .Select(s => new ScheduleDto()
                                {
                                    ScheduleId = s.ScheduleId,
                                    Date = SqlFunctions.DateName("day", s.Date) + "/" + SqlFunctions.DateName("month", s.Date) + "/" + SqlFunctions.DateName("year", s.Date),
                                    SlotNo = s.SlotId,
                                    TeacherId = s.TeacherId,
                                    ClassId = s.ClassId,
                                    AttendanceStatus = s.AttendanceStatus,
                                    ReportStatus = s.ReportStatus
                                }).ToList();
            }
            else if (request.RoleName.Equals("teacher"))
            {

            }
            response.Schedules = scheduleList;
            return response;
        }
    }
}
