using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Contract.Models;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using FaceRecognition.BusinessLogic.Interfaces;
using FaceRecognition.BusinessLogic.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FaceRecognition.BusinessLogic.Components
{
    public class AttendanceManagement : IAttendanceManagement, IDisposable
    {
        private readonly FaceRecognitionContext _context;
        public AttendanceManagement()
        {
            _context = new FaceRecognitionContext();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<TakeAttendanceByImageResponse> TakeAttendanceByImage(TakeAttendanceByImageRequest request)
        {
            TakeAttendanceByImageResponse response = new TakeAttendanceByImageResponse();
            var rootImages = new List<RootImage>();
            var locationImagePath = Path.Combine(HttpRuntime.AppDomainAppPath, Constants.Config.AttendanceImagePath,request.Date.ToString("yyyyMMdd"), request.ClassId, request.SlotId.ToString());
            ImageConverter.CreateDirectory(locationImagePath);
            int numberOfImage = 1;
            await Task.Run(async () =>
            {
                foreach (var imageUrl in request.ImageUrls)
                {
                    var image = await GetImages(imageUrl);
                    rootImages.Add(image);
                    //save image to folder
                    ImageConverter.Base64ToImage(Path.Combine(locationImagePath, numberOfImage + ".jpg"), imageUrl);
                    numberOfImage++;
                }
            });

            var listCandidateId = new List<string>();
            try
            {
                foreach (var rootImage in rootImages)
                {
                    foreach (var image in rootImage.Images)
                    {
                        if (image.Candidates != null && image.Transaction.Status.Equals(Constants.KairosApi.TransactionSuccess))
                        {
                            var firstCandidate = image.Candidates.OrderByDescending(c => c.Confidence).First();
                            listCandidateId.Add(firstCandidate.SubjectId);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            listCandidateId = listCandidateId.Distinct().ToList();
            var studentList = (from sd in _context.Schedules
                               where sd.TeacherId == request.UserId
                               && sd.Date == request.Date
                               && sd.SlotId == request.SlotId
                               select sd).ToList();
            List<StudentAttendance> students = new List<StudentAttendance>();
            foreach (var student in studentList)
            {
                if (listCandidateId.Any(x => x.Equals(student.StudentId)))
                {
                    student.AttendanceStatus = Constants.AttendanceStatus.Presented;
                }
                else
                {
                    student.AttendanceStatus = Constants.AttendanceStatus.Absent;
                }
                var studentAttendance = (from st in _context.Students
                                         where st.StudentId == student.StudentId
                                         select new StudentAttendance()
                                         {
                                             StudentId = st.StudentId,
                                             FullName = st.FullName,
                                             Email = st.Email,
                                             AttendanceStatus = student.AttendanceStatus
                                         }).First();
                students.Add(studentAttendance);
            }
            _context.SaveChanges();
            response.Students = students;
            return response;
        }

        public TakeAttendanceManuallyResponse TakeAttendanceManually(TakeAttendanceManuallyRequest request)
        {
            TakeAttendanceManuallyResponse response = new TakeAttendanceManuallyResponse();
            foreach (var student in request.Students)
            {
                var attendance = (from sd in _context.Schedules
                                  where sd.TeacherId == request.UserId
                                  && sd.Date == request.Date
                                  && sd.SlotId == request.SlotId
                                  && sd.StudentId == student.StudentId
                                  select sd).First();
                attendance.AttendanceStatus = student.AttendanceStatus;
            }
            _context.SaveChanges();
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
