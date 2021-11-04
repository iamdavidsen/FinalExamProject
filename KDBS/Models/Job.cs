using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KDBS.Data;

namespace KDBS.Models
{
    public class Job
    {
        [Required]
        public string JobTitle { get; set; }

        public string JobContent { get; set; }
        public string CategoryId { get; set; }
        public int Salary { get; set; }
        public List<Category> Categories { get; set; }
        public List<Goods> Goods { get; set; }

    }

    public class Goods : GoodsModel
    {
        public bool IsSelected { get; set; }
    }

    public class Category : CategoryModel
    {

    }
}
