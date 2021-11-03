using System.Collections.Generic;

namespace KDBS.Data
{
    public class CategoryModel
    {
        public string CategoryId { get; set; }

        public string Title { get; set; }

        public virtual List<JobModel> Jobs { get; set; }
    }
}
