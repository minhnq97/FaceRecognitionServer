using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Response
{
    /// <summary>
    /// Response Model when returning a list of terms response to client
    /// </summary>
    public class TermResponse : BaseResponse
    {
        public List<TermDto> Terms;
    }
}
