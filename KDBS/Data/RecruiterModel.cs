using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KDBS.Data
{
    public class RecruiterModel
    {
        public string RecruiterId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string Address { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }
        
        public virtual UserModel User { get; set; }
        
        public string UserId { get; set; }

        public virtual List<JobModel> Jobs { get; set; }
    }
}
