using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components;

namespace KDBS.Data
{
    public class JobModel
    {
        public string JobId { get; set; }

        public string? Slug { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public int Salary { get; set; }
        public string LinkToCompany { get; set; }

        public DateTime Added { get; set; }

        public DateTime Edited { get; set; }
        
        public virtual CompanyModel Company { get; set; }
        
        public string CompanyId { get; set; }
        
        public virtual CategoryModel? Category { get; set; }
        
        public string? CategoryId { get; set; }
        
        public virtual List<GoodsModel> Goods { get; set; }
    }
}
