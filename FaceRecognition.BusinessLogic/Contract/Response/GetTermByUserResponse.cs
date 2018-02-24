using FaceRecognition.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Response
{
    public class GetTermByUserResponse:BaseResponse
    {
        public List<TermDto> Terms;
    }
}
