using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Request
{
    public class TakeAttendanceByImageRequest:BaseRequest
    {
        public List<String> ImageUrls { get; set; }
        public string GalleryName { get; set; }
    }
}
