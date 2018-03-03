using FaceRecognition.BusinessLogic.Contract.Models;
using FaceRecognition.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Response
{
    public class GetSlotByTeacherResponse: BaseResponse
    {
        public List<SlotInformation> SlotInformationList { get; set; }
    }
}
