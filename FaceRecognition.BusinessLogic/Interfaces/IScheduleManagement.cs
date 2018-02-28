using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface relating to schedule management methods
    /// </summary>
    public interface IScheduleManagement
    {
        TermResponse GetTermByUser(GetTermByUserRequest request);
        GetCourseByTermResponse GetCourseByTerm(GetCourseByTermRequest request);
    }
}
