using FaceRecognition.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition.BusinessLogic.Contract.Request;
using FaceRecognition.BusinessLogic.Contract.Response;
using DemoFaceRecognition.Context;
using FaceRecognition.BusinessLogic.Utils;

namespace FaceRecognition.BusinessLogic.Components
{
    public class LoginManagement : ILoginManagement
    {
        private readonly FaceRecognitionContext _context = new FaceRecognitionContext();

        public void Dispose()
        {
            _context.Dispose();
        }

        public GetUserByIdTokenResponse GetUserByIdToken(GetUserByIdTokenRequest request)
        {
            GetUserByIdTokenResponse response = null;
            string idToken = request.IdToken;
            string verifiedEmail = GoogleApiTokenVerifier.VerifyIdToken(idToken);

            if (verifiedEmail != null)
            {
                var student = _context.Students.Where(s => s.Email == verifiedEmail).SingleOrDefault();
                if (student != null)
                {
                    response = new GetUserByIdTokenResponse()
                    {
                        UserId = student.StudentId,
                        FullName = student.FullName,
                        UserEmail = student.Email,
                        UserRole = "student"
                    };
                }
                else
                {
                    var teacher = _context.Teachers.Where(t => t.Email == verifiedEmail).SingleOrDefault();
                    if (teacher != null)
                    {
                        response = new GetUserByIdTokenResponse()
                        {
                            UserId = teacher.TeacherId,
                            FullName = teacher.FullName,
                            UserEmail = teacher.Email,
                            UserRole = "teacher"
                        };
                    }
                }
            }
            return response;
        }
    }
}
