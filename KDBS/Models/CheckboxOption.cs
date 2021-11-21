namespace KDBS.Models
{
    public class CheckboxOption
    {
        public string Id;
        public bool Selected;
        public string Title;

        public CheckboxOption() {}

        public CheckboxOption(string id, string title, bool selected)
        {
            Id = id;
            Title = title;
            Selected = selected;
        }
    }
}
