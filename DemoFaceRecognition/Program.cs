using DemoFaceRecognition.Context;
using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFaceRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FaceRecognitionContext())
            {
                var query = from u in db.Students
                            orderby u.StudentId
                            select u;

                foreach (var item in query)
                {
                    Console.WriteLine(item.StudentId + ": " + item.FullName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
