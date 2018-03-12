using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.BusinessLogic.Contract.Models
{
    public class Image
    {
        public List<Candidate> Candidates { get; set; }
        public Transaction Transaction { get; set; }
    }
}
