using FaceRecognition.BusinessLogic.Components;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace FaceRecognition.Api.Controllers
{
    public class AttendanceManagementController : ApiController
    {
        private readonly IAttendanceManagement _businessLogic;

        public AttendanceManagementController()
        {
            _businessLogic = new AttendanceManagement();
        }

        [HttpPost]
        public async Task<TakeAttendanceByImageResponse> TakeAttendanceByImage(TakeAttendanceByImageRequest request)
        {
            var response = await _businessLogic.TakeAttendanceByImage(request);
            return response;
        }

        [HttpPost]
        public TakeAttendanceManuallyResponse TakeAttendanceManually(TakeAttendanceManuallyRequest request)
        {
            var response = _businessLogic.TakeAttendanceManually(request);
            return response;
        }
    }
}
