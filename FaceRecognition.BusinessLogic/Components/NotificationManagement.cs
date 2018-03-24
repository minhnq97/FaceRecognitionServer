using FaceRecognition.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Contract.Models;
using System.Data.Entity.SqlServer;
using FaceRecognition.BusinessLogic.Models;

namespace FaceRecognition.BusinessLogic.Components
{
    public class NotificationManagement : INotificationManagement
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public GetNotificationsByTeacherIdResponse GetNotificationsByTeacherId(GetNotificationsByTeacherIdRequest request)
        {
            GetNotificationsByTeacherIdResponse response = new GetNotificationsByTeacherIdResponse();
            var twoDaysBefore = DateTime.Now.Date.AddDays(-2);
            var notificationList = _context.Schedules
                                    .Where(s => s.TeacherId == request.UserId
                                             && s.ReportStatus == "Reported"
                                             && s.Date >= twoDaysBefore)
                                    .Select(s => new
                                    {
                                        ScheduleId = s.ScheduleId,
                                        ClassId = s.Class.ClassId,
                                        ClassName = s.Class.ClassName,
                                        StudentId = s.StudentId,
                                        CourseId = s.CourseId,
                                        CourseName = s.Course.CourseName,
                                        SlotId = s.SlotId,
                                        StartTime = s.Slot.StartTime,
                                        EndTime = s.Slot.EndTime,
                                        Date = s.Date
                                    })
                                    .Select(s => new NotificationInfo()
                                    {
                                        ScheduleId = s.ScheduleId,
                                        Classes = new ClassDto() { ClassId = s.ClassId, ClassName = s.ClassName },
                                        StudentId = s.StudentId,
                                        Course = new CourseDto() { CourseId = s.CourseId, CourseName = s.CourseName },
                                        Slot = new SlotDto() { SlotId = s.SlotId, StartTime = s.StartTime, EndTime = s.EndTime },
                                        Date = SqlFunctions.DateName("day", s.Date) + "/" + SqlFunctions.DateName("month", s.Date) + "/" + SqlFunctions.DateName("year", s.Date)
                                    }).ToList();

            response.Notifications = notificationList;

            return response;
        }
    }
}
