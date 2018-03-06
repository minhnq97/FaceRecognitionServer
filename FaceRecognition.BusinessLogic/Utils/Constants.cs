using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Utils
{
    public static class Constants
    {
        public class UserRole
        {
            public const string Teacher = "teacher";
            public const string Student = "student";
        }

        public class AttendanceStatus
        {
            public const string NotYet = "Not Yet";
            public const string Present = "Present";
            public const string Absent = "Absent";
        }
    }
}
