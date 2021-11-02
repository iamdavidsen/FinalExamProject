using System;
using System.ComponentModel.DataAnnotations;
using KDBS.Data;

namespace KDBS.Models
{
    public class Job
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
