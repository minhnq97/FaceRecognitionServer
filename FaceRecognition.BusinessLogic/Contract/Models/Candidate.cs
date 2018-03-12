using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class Candidate
    {
        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("enrollment_timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("face_id")]
        public string FaceId { get; set; }

        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }
    }
}
