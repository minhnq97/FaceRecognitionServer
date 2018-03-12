using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Interfaces
{
    public interface INotificationManagement
    {
        GetNotificationsByTeacherIdResponse GetNotificationsByTeacherId(GetNotificationsByTeacherIdRequest request);
    }
}
