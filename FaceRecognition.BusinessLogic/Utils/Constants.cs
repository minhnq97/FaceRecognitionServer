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
            public const string Presented = "Presented";
            public const string Absent = "Absent";
        }

        public class KairosApi
        {
            public const string AppId = "fe96ef60";
            public const string Key = "e37a05bf688189d31801e0aff09932ae";
            public const string GalleryName = "IS1101";
            public const string ApiRecognize = @"https://api.kairos.com/recognize";
            public const string TransactionSuccess = "success";
            public const string TransactionFailure = "failure";
        }

        public class Config
        {
            public const string AttendanceImagePath = @"Images\attendance\";
        }
    }
}
