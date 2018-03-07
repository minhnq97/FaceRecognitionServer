using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class ReportInfoModel
    {
        public long ScheduleId { get; set; }
        public string TeacherId { get; set; }
        public string StudentId { get; set; }
        public int SlotId { get; set; } 
        public string Date { get; set; }
    }
}
