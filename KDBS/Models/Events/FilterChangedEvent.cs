using System.Collections.Generic;

namespace KDBS.Models.Events
{
    public class FilterChangedEvent
    {
        public List<string> Categories;
        public List<string> Goods;
        public int Salary;
        public string SearchQuery;

        public FilterChangedEvent(string searchQuery, int salary, List<string> categories, List<string> goods)
        {
            SearchQuery = searchQuery;
            Salary = salary;
            Categories = categories;
            Goods = goods;
        }
    }
}
