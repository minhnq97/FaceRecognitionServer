using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFaceRecognition.Model
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}
