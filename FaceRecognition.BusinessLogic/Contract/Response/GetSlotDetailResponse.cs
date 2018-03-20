using FaceRecognition.BusinessLogic.Contract.Models;
using System.Collections.Generic;

namespace FaceRecognition.BusinessLogic.Contract.Response
{
    public class GetSlotDetailResponse : BaseResponse
    {
        public SlotInformation SlotInformation { get; set; }
        public List<StudentAttendance> Students { get; set; }
        public int AttendedStudents { get; set; }
    }
}
