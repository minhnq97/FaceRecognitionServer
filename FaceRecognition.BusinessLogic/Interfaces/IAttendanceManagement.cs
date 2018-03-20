using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Interfaces
{
    public interface IAttendanceManagement
    {
        Task<TakeAttendanceByImageResponse> TakeAttendanceByImage(TakeAttendanceByImageRequest request);

        TakeAttendanceManuallyResponse TakeAttendanceManually(TakeAttendanceManuallyRequest request);
    }
}
