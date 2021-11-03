using System.Collections.Generic;

namespace KDBS.Data
{
    public class GoodsModel
    {
        public string GoodsId { get; set; }

        public string Title { get; set; }

        public virtual List<JobModel> Jobs { get; set; }
    }
}
