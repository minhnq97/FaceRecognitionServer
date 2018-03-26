using System;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    public class GetSlotDetailRequest : BaseRequest
    {
        public int SlotId;
        public string ClassId;
        public DateTime Date;
    }
}
