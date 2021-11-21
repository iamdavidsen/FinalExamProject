using System.Collections.Generic;

namespace KDBS.Data
{
    public class CompanyModel
    {
        public string CompanyId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual UserModel User { get; set; }

        public string UserId { get; set; }

        public virtual List<JobModel> Jobs { get; set; }
    }
}
