using FaceRecognition.BusinessLogic.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    public class TakeAttendanceManuallyRequest:BaseRequest
    {
        public List<StudentAttendance> Students { get; set; }
        public DateTime Date { get; set; }
        public int SlotId { get; set; }
    }
}
