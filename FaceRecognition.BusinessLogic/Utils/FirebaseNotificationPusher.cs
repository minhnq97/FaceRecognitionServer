using FaceRecognition.BusinessLogic.Contract.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Utils
{
    public class FirebaseNotificationPusher
    {
        private const string FIREBASE_SERVER_KEY = "AAAAlBpQgf0:APA91bEqm8KQR9tuJjFBRy2vatSGTIQWhmsmLQ-Op6xMN2VyJIHnKe45k8lrz0VOU-p4T2Bt53GzDmhkqypwvZLozqn3QAXWIDX6JHT8g3SIQ1Du8jg5Xojv_34P-ugFa7tCenNirc2K";
        private const string FIREBASE_PUSH_URL = "https://fcm.googleapis.com/fcm/send";

        public static async void Send(FirebaseNotificationModel firebaseNotifiModel)
        {
            HttpRequestMessage httpRequest = null;
            HttpClient httpClient = null;

            var authorizationKey = string.Format("key={0}", FIREBASE_SERVER_KEY);
            var jsonBody = JsonConvert.SerializeObject(firebaseNotifiModel);

            try
            {
                httpRequest = new HttpRequestMessage(HttpMethod.Post, FIREBASE_PUSH_URL);
                httpRequest.Headers.TryAddWithoutValidation("Authorization", authorizationKey);
                httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                httpClient = new HttpClient();
                using (await httpClient.SendAsync(httpRequest))
                {

                }
            }
            catch
            {
                throw;
            }
        }
    }
}
