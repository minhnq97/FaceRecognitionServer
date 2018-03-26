using System;
using System.IO;
using System.Web;

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

        public static bool CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Base64ToImage(string savePath, string imageBase64)
        {
            try
            {
                var bytes = Convert.FromBase64String(imageBase64);
                using (var imageFile = new FileStream(Path.Combine(HttpRuntime.AppDomainAppPath, savePath), FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
