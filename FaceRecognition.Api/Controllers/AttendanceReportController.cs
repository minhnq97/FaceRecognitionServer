using FaceRecognition.BusinessLogic.Contract.Models;
using FaceRecognition.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaceRecognition.Api.Controllers
{
    public class AttendanceReportController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ReportToTeacher()
        {
            FirebaseNotificationModel firebaseModel = new FirebaseNotificationModel()
            {
                To = "",
                Notification = new NotificationModel()
                {
                    Title = "Make it happen",
                    Body = "This is message body"
                }
            };
            FirebaseNotificationPusher.Send(firebaseModel);
            return null;
        }
    }
}
