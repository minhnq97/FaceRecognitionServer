using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.Api.Models
{
    public class SlotDto
    {
        public int SlotId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}