using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    /// <summary>
    /// Request Model for a list of courses request from client
    /// </summary>
    public class GetCourseByTermRequest : BaseRequest
    {
        public string TermId { get; set; }
    }
}
