namespace KDBS.Models.Events
{
    public class PinClickEvent
    {
        public string Id { get; set; }

        public int PageX { get; set; }

        public int PageY { get; set; }

        public int ScreenHeight { get; set; }
        public int ScreenWidth { get; set; }

    }
}
