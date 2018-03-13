using FaceRecognition.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Models;
using FaceRecognition.BusinessLogic.Contract.Models;
using FaceRecognition.BusinessLogic.Utils;

namespace FaceRecognition.BusinessLogic.Components
{
    public class SlotManagement : ISlotManagement, IDisposable
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public void Dispose()
        {
            _context.Dispose();
        }

        public GetSlotByTeacherResponse GetSlotByTeacher(GetSlotByTeacherRequest request)
        {
            GetSlotByTeacherResponse response = new GetSlotByTeacherResponse();
            if(request.RoleName.Equals(Constants.UserRole.Teacher))
            {
                var slotInformationList = (from sd in _context.Schedules
                            join sc in _context.Slots
                                on sd.SlotId equals sc.SlotId
                            join cs in _context.Courses
                                on sd.CourseId equals cs.CourseId
                            join cl in _context.Classes
                                on sd.ClassId equals cl.ClassId
                            where sd.TeacherId == request.UserId && sd.Date == request.date
                            select new SlotInformation()
                            {
                                Slot = new SlotDto()
                                {
                                    SlotId = sd.SlotId,
                                    StartTime = sc.StartTime,
                                    EndTime = sc.EndTime
                                },
                                Course = new CourseDto()
                                {
                                    CourseId = sd.CourseId,
                                    CourseName = cs.CourseName
                                },
                                Classes = new ClassDto()
                                {
                                    ClassId = sd.ClassId,
                                    ClassName = cl.ClassName
                                }
                            }).Distinct().ToList();
                response.SlotInformationList = slotInformationList;
                return response;
            }
            return response;
        }

        public GetSlotDetailResponse GetSlotDetail(GetSlotDetailRequest request)
        {
            try
            {
                if(request.RoleName.Equals(Constants.UserRole.Teacher))
                {
                    var listStudent = (from sd in _context.Schedules
                                       join std in _context.Students
                                          on sd.StudentId equals std.StudentId
                                       where sd.SlotId == request.SlotId
                                          && sd.ClassId == request.ClassId
                                          && sd.Date == request.Date
                                       select new StudentAttendance()
                                       {
                                           StudentId = sd.StudentId,
                                           FullName = std.FullName,
                                           Email = std.Email,
                                           Image = std.Image,
                                           AttendanceStatus = sd.AttendanceStatus
                                       }).ToList();

                    listStudent.ForEach(s => s.Image = ImageConverter.ToBase64(s.Image));

                    var slotInformation = (from sd in _context.Schedules
                                               join sc in _context.Slots
                                                   on sd.SlotId equals sc.SlotId
                                               join cs in _context.Courses
                                                   on sd.CourseId equals cs.CourseId
                                               join cl in _context.Classes
                                                   on sd.ClassId equals cl.ClassId
                                               where sd.TeacherId == request.UserId && sd.Date == request.Date && sd.SlotId == request.SlotId
                                               select new SlotInformation()
                                               {
                                                   Slot = new SlotDto()
                                                   {
                                                       SlotId = sd.SlotId,
                                                       StartTime = sc.StartTime,
                                                       EndTime = sc.EndTime
                                                   },
                                                   Course = new CourseDto()
                                                   {
                                                       CourseId = sd.CourseId,
                                                       CourseName = cs.CourseName
                                                   },
                                                   Classes = new ClassDto()
                                                   {
                                                       ClassId = sd.ClassId,
                                                       ClassName = cl.ClassName
                                                   }
                                               });
                    return new GetSlotDetailResponse()
                    {
                        Students = listStudent,
                        SlotInformation = (SlotInformation)slotInformation.First()
                    };
                }
                return null; //return error response  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null; //return error response
            }
        }
    }
}
