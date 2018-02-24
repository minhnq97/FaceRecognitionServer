using DemoFaceRecognition.Context;
using FaceRecognition.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FaceRecognition.BusinessLogic.Interfaces;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Components;

namespace FaceRecognition.Api.Controllers
{
    public class ScheduleManagementController : ApiController
    {
        private readonly IScheduleManagement _businessLogic = new ScheduleManagement();

        [HttpPost]
        public GetTermByUserResponse GetTermByUser(GetTermByUserRequest request)
        {
            var response = _businessLogic.GetTermByUser(request);
            return response;
        }

        [HttpPost]
        public GetCourseByTermResponse GetCourseByTerm(GetCourseByTermRequest request)
        {
            var response = _businessLogic.GetCourseByTerm(request);
            return response;
        }
    }
}
