using System;
using System.Collections.Generic;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    public class TakeAttendanceByImageRequest : BaseRequest
    {
        public List<String> ImageUrls { get; set; }
        public string GalleryName { get; set; }
        public DateTime Date { get; set; }
        public int SlotId { get; set; }
        public string ClassId { get; set; }
    }
}
