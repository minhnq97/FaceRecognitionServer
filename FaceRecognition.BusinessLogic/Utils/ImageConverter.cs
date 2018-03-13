using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Utils
{
    public class ImageConverter
    {
        public static string ToBase64(string imagePath)
        {
            if (imagePath == null) { return imagePath; }
            return Convert.ToBase64String(File.ReadAllBytes(
                System.Web.HttpContext.Current.Request.MapPath(@"~\" + imagePath))
                );
        }
    }
}
