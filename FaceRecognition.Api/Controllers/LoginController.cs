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
    public class LoginController : ApiController
    {
        private readonly ILoginManagement _businessLogic = new LoginManagement();

        [HttpPost]
        public HttpResponseMessage GetTermByUser()
        {
            // Receive google id token from the client
            string idToken = Request.Headers.GetValues("idToken").FirstOrDefault();
            if (idToken == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            GetUserByIdTokenRequest request = new GetUserByIdTokenRequest() { IdToken = idToken };
            var responseModel = _businessLogic.GetUserByIdToken(request);

            // Response to client, Not Found if no user are found, otherwise OK
            if (responseModel == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(responseModel), Encoding.UTF8, "application/json");

            return response;
        }
    }
}
