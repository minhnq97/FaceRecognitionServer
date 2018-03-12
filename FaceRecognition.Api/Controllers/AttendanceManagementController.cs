using FaceRecognition.BusinessLogic.Components;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaceRecognition.Api.Controllers
{
    public class AttendanceManagementController : ApiController
    {
        private readonly IAttendanceManagement _businessLogic = new AttendanceManagement();

        [HttpPost]
        public TakeAttendanceByImageResponse TakeAttendanceByImage(TakeAttendanceByImageRequest request)
        {
            var response = _businessLogic.TakeAttendanceByImage(request);
            return response;
        }
    }
}
