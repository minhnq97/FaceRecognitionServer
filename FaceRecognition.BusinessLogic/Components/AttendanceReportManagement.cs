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
    public class AttendanceReportManagement
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public async Task<ReportToTeacherByScheduleIdResponse> ReportToTeacherByScheduleId(ReportToTeacherByScheduleIdRequest request)
        {
            int scheduleId = Convert.ToInt32(request.ScheduleId);
            var reportedSchedule = _context.Schedules
                                        .Where(s => s.ScheduleId == scheduleId)
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
                        Title = "Attendance Report Date " + reportedSchedule.Date,
                        Body = "Student with ID " + reportedSchedule.StudentId + " has reported attendance on slot " + reportedSchedule.SlotId
                    }
                };

                // Send notification to the responsible teacher
                await FirebaseNotificationPusher.Send(firebaseNotiModel);

            }

            return null;
        }
    }
}
