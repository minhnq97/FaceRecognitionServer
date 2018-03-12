using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Contract.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using FaceRecognition.BusinessLogic.Utils;
using Newtonsoft.Json;

namespace FaceRecognition.BusinessLogic.Components
{
    public class AttendanceManagement : IAttendanceManagement, IDisposable
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();
        public const string ImageUrl1 = @"https://scontent.fhan3-2.fna.fbcdn.net/v/t1.0-9/29062743_770024833189538_2847824013172932608_n.jpg?oh=26836cdcc45099ea750f2f4e8822251f&oe=5B39FAA7";
        public const string ImageUrl2 = @"https://scontent.fhan3-2.fna.fbcdn.net/v/t1.0-9/24068363_770025543189467_5619623428714659840_n.jpg?oh=36056f1bb7781912193fcc1d3d4841d2&oe=5B4A4901";

        public void Dispose()
        {
            _context.Dispose();
        }

        public TakeAttendanceByImageResponse TakeAttendanceByImage(TakeAttendanceByImageRequest request)
        {
            TakeAttendanceByImageResponse response = new TakeAttendanceByImageResponse();
            request.ImageUrls.Add(ImageUrl1);
            request.ImageUrls.Add(ImageUrl2);
            var rootImages = new List<RootImage>();
            foreach (var imageUrl in request.ImageUrls)
            {
                Task<RootImage> task = Task.Run<RootImage>(async () => await GetImages(imageUrl));
                var rootImage = task.Result;
                rootImages.Add(rootImage);
            }

            return response;
        }

        private async Task<RootImage> GetImages(string imageUrl)
        {
            HttpClient client = new HttpClient();

            var values = new Dictionary<string, string>
            {
               { "image", imageUrl },
               {"gallery_name",Constants.KairosApi.GalleryName}
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("app_id", Constants.KairosApi.AppId);
            client.DefaultRequestHeaders.Add("app_key", Constants.KairosApi.Key);
            var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Constants.KairosApi.ApiRecognize, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var rootObj = JsonConvert.DeserializeObject<RootImage>(responseString);

            return rootObj;
        }
    }
}
