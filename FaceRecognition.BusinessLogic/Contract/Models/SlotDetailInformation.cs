using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class SlotDetailInformation
    {
        public SlotInformation SlotInformation { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
