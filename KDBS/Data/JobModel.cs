using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components;

namespace KDBS.Data
{
    public class JobModel
    {
        public string JobId { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Added { get; set; }

        public DateTime Edited { get; set; }
        
        public virtual RecruiterModel Recruiter { get; set; }
        
        public string RecruiterId { get; set; }
    }
}
