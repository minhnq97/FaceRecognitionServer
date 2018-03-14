using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Interfaces
{
    public interface IAttendanceManagement
    {
        TakeAttendanceByImageResponse TakeAttendanceByImage(TakeAttendanceByImageRequest request);

        TakeAttendanceManuallyResponse TakeAttendanceManually(TakeAttendanceManuallyRequest request);
    }
}
