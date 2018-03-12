using FaceRecognition.BusinessLogic.Components;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace FaceRecognition.Api.Controllers
{
    public class NotificationController : ApiController
    {
        private readonly INotificationManagement _businessLogic = new NotificationManagement();

        [HttpPost]
        public HttpResponseMessage GetNotificationsByTeacherId(GetNotificationsByTeacherIdRequest request)
        {
            var responseModel = _businessLogic.GetNotificationsByTeacherId(request);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(responseModel), Encoding.UTF8, "application/json"); ;

            return response;
        }
    }
}
