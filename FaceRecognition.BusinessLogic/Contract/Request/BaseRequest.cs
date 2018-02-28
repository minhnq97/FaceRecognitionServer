using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    /// <summary>
    /// Base Request Model for all requests sent by clients
    /// </summary>
    public class BaseRequest
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
