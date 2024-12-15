namespace BoardAppFront.Entities
{
    public class UpdateAnnouncementRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
