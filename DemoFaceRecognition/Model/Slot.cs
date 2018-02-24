using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFaceRecognition.Model
{
    public class Slot
    {
        public int SlotId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}
