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
        public string ClassId { get; set; }
        public string StudentId { get; set; }
        public string CourseName { get; set; }
        public int SlotId { get; set; }
        public string Date { get; set; }
    }
}
