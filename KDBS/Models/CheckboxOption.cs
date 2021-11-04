namespace KDBS.Models
{
    public class CheckboxOption
    {
        public string Id;
        public string Title;
        public bool Selected;
        
        public CheckboxOption() {}
        
        public CheckboxOption(string id, string title, bool selected)
        {
            Id = id;
            Title = title;
            Selected = selected;
        }
    }
}
