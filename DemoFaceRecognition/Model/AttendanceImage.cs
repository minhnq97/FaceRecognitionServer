using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFaceRecognition.Model
{
    public class AttendanceImage
    {
        public int AttendanceImageId { get; set; }
        public string ImagePath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}
