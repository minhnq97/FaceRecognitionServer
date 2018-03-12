using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class Transaction
    {
        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("enrollment_timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("eyeDistance")]
        public int EyeDistance { get; set; }

        [JsonProperty("face_id")]
        public string FaceId { get; set; }

        [JsonProperty("gallery_name")]
        public string GalleryName { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("pitch")]
        public int Pitch { get; set; }

        [JsonProperty("quality")]
        public double Quality { get; set; }

        [JsonProperty("roll")]
        public int Roll { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }

        [JsonProperty("topLeftX")]
        public string TopLeftX { get; set; }

        [JsonProperty("topLeftY")]
        public string TopLeftY { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("yaw")]
        public int Yaw { get; set; }
    }
}
