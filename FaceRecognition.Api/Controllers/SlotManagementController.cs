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
    public class SlotManagementController : ApiController
    {
        private readonly ISlotManagement _businessLogic = new SlotManagement();

        [HttpPost]
        public GetSlotByTeacherResponse GetSlotByTeacher(GetSlotByTeacherRequest request)
        {
            var response = _businessLogic.GetSlotByTeacher(request);
            return response;
        }
    }
}
