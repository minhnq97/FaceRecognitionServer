using FaceRecognition.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition.BusinessLogic.Contract.Request;
using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Contract.Models;
using FaceRecognition.BusinessLogic.Utils;
using FaceRecognition.BusinessLogic.Contract.Response;

namespace FaceRecognition.BusinessLogic.Components
{
    public class AttendanceReportManagement : IAttendanceReportManagement
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public ReportToTeacherByScheduleIdResponse ReportToTeacherByScheduleId(ReportToTeacherByScheduleIdRequest request)
        {
            var reportedSchedule = _context.Schedules
                                        .Where(s => s.ScheduleId == Convert.ToInt32(request.ScheduleId))
                                        .FirstOrDefault();
            if (reportedSchedule != null)
            {
                // Change attendance report status to Reported
                reportedSchedule.ReportStatus = "Reported";
                _context.SaveChanges();

                FirebaseNotificationModel firebaseNotiModel = new FirebaseNotificationModel()
                {
                    To = "/topics/teacher_" + reportedSchedule.TeacherId,
                    Notification = new NotificationModel()
                    {
                        Title = "Attendance Report",
                        Body = "Student " + 
                                reportedSchedule.StudentId + " has reported attendance on " 
                                + reportedSchedule.SlotId + 
                                " on " + reportedSchedule.Date
                    }
                };

                // Send notification to the responsible teacher
                FirebaseNotificationPusher.Send(firebaseNotiModel);

            }

            return new ReportToTeacherByScheduleIdResponse();
        }
    }
}
