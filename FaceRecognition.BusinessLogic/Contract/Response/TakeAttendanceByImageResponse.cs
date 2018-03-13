using FaceRecognition.BusinessLogic.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Response
{
    public class TakeAttendanceByImageResponse:BaseResponse
    {
        public List<StudentAttendance> Students { get; set; }
    }
}
