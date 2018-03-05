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
            if(request.RoleName.Equals("teacher"))
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
                                Class = new ClassDto()
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
    }
}
