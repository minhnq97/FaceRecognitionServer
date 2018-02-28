using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.BusinessLogic.Models
{
    /// <summary>
    /// Entity representing table Terms in the database
    /// </summary>
    public class TermDto
    {
        public string TermId { get; set; }
        public string TermName { get; set; }
    }
}