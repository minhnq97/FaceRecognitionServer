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

namespace FaceRecognition.BusinessLogic.Components
{
    public class NotificationManagement : INotificationManagement
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public GetNotificationsByTeacherIdResponse GetNotificationsByTeacherId(GetNotificationsByTeacherIdRequest request)
        {
            GetNotificationsByTeacherIdResponse response = new GetNotificationsByTeacherIdResponse();
            var notificationList = _context.Schedules
                                    .Where(s => s.TeacherId == request.UserId
                                             && s.ReportStatus == "Reported"
                                             /*&& s.Date >= DateTime.Now.Date.AddDays(-2)*/)
                                    .Select(s => new
                                    {
                                        ScheduleId = s.ScheduleId,
                                        ClassId = s.ClassId,
                                        TeacherId = s.TeacherId,
                                        StudentId = s.StudentId,
                                        CourseName = s.Course.CourseName,
                                        SlotId = s.SlotId,
                                        Date = s.Date
                                    }).GroupBy(s => new { s.TeacherId })
                                    .Select(s => new NotificationInfo()
                                    {
                                        ScheduleId = s.FirstOrDefault().ScheduleId,
                                        ClassId = s.FirstOrDefault().ClassId,
                                        StudentId = s.FirstOrDefault().StudentId,
                                        CourseName = s.FirstOrDefault().CourseName,
                                        SlotId = s.FirstOrDefault().SlotId,
                                        Date = SqlFunctions.DateName("day", s.FirstOrDefault().Date) + "/" + SqlFunctions.DateName("month", s.FirstOrDefault().Date) + "/" + SqlFunctions.DateName("year", s.FirstOrDefault().Date)
                                    }).ToList();

            response.Notifications = notificationList;

            return response;
        }
    }
}
