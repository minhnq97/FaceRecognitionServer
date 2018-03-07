using Newtonsoft.Json;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class NotificationModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
    }
}