using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class SlotInformation
    {
        public SlotDto Slot { get; set; }
        public CourseDto Course { get; set; }
        public ClassDto Class { get; set; }
    }
}
