﻿using DemoFaceRecognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceRecognition.BusinessLogic.Models
{
    /// <summary>
    /// Entity representing table Classes in the database
    /// </summary>
    public class ClassDto
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
    }
}