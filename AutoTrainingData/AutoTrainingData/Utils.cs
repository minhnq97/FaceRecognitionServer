using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainingData
{
    public static class Utils
    {
        public static string GetConfig(string KeyName)
        {
            return ConfigurationManager.AppSettings[KeyName];
        }

        public static string ToBase64(string imagePath)
        {
            if (imagePath == null) return imagePath;
            return Convert.ToBase64String(File.ReadAllBytes(imagePath));
        }
    }
}
