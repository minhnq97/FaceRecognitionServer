using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Response
{
    public class GetUserByIdTokenResponse : BaseResponse
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
    }
}
