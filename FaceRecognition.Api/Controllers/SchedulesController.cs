using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaceRecognition.Api.Controllers
{
    using BusinessLogic.Models;
    using DemoFaceRecognition.Context;

    public class SchedulesController : ApiController
    {
        public FaceRecognitionContext _context = new FaceRecognitionContext();
        
        public IEnumerable<ScheduleDto> GetAllSchedules()
        {
            return _context.Schedules.Select(s => new ScheduleDto()
            {
                ScheduleId = s.ScheduleId,
                Date = s.Date,
                Room = s.Room,
                AttendanceStatus = s.AttendanceStatus,
                ReportStatus = s.ReportStatus,
                Slot = s.Slot,
                Student = s.Student,
                Teacher = s.Teacher,
                Course = s.Course,
                Term = s.Term,
                AttendanceImages = s.AttendanceImages.ToList(),
                Class = s.Class
            });
        }

        public IHttpActionResult GetSchedule(int id)
        {
            var schedule = _context.Schedules.FirstOrDefault((s) => s.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
    }
}
