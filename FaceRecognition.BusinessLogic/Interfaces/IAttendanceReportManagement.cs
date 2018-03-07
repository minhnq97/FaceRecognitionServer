using FaceRecognition.BusinessLogic.Contract.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Interfaces
{
    public interface IAttendanceReportManagement
    {
        void ReportToTeacherByScheduleId(ReportToTeacherByScheduleIdRequest request);
    }
}
