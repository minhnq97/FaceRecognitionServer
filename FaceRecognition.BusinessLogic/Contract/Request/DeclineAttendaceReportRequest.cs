using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    public class DeclineAttendaceReportRequest : BaseRequest
    {
        public string ScheduleId { get; set; }
    }
}
