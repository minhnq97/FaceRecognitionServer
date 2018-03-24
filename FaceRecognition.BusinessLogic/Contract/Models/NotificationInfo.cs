using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class NotificationInfo
    {
        public long ScheduleId { get; set; }
        public ClassDto Classes { get; set; }
        public string StudentId { get; set; }
        public CourseDto Course { get; set; }
        public SlotDto Slot { get; set; }
        public string Date { get; set; }
    }
}
