using FaceRecognition.BusinessLogic.Components;
using FaceRecognition.BusinessLogic.Contract.Models;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Interfaces;
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
        private readonly AttendanceReportManagement _businessLogic = new AttendanceReportManagement();

        [HttpPost]
        public HttpResponseMessage ReportToTeacher(ReportToTeacherByScheduleIdRequest request)
        {
            var response = _businessLogic.ReportToTeacherByScheduleId(request);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage DeclineAttendanceByTeacher(DeclineAttendaceReportRequest request)
        {
            var response = _businessLogic.DeclineAttendanceReport(request);
            if (response == null) return Request.CreateResponse(HttpStatusCode.InternalServerError);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
