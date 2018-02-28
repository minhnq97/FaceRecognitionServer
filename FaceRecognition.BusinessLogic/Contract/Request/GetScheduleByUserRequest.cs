using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    /// <summary>
    /// Request Model for a list of schedules request from client
    /// </summary>
    public class GetScheduleByUserRequest : BaseRequest
    {
        public string TermId { get; set; }
        public string CourseId { get; set; }
    }
}
