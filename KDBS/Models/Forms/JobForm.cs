using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KDBS.Models
{
    public class JobForm
    {
        [Required]
        public string JobTitle { get; set; }

        public string JobContent { get; set; }

        public string CategoryId { get; set; }

        public int Salary { get; set; }

        public string LinkToCompany { get; set; }

        public List<CheckboxOption> Categories { get; set; }

        public List<CheckboxOption> Goods { get; set; }
    }
}
