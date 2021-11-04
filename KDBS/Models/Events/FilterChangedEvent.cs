using System.Collections.Generic;

namespace KDBS.Models.Events
{
    public class FilterChangedEvent
    {
        public string SearchQuery;
        public int Salary;
        public List<string> Categories;
        public List<string> Goods;
        
        public FilterChangedEvent(string searchQuery, int salary, List<string> categories, List<string> goods)
        {
            SearchQuery = searchQuery;
            Salary = salary;
            Categories = categories;
            Goods = goods;
        }
    }
}
