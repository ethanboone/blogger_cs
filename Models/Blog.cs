namespace blogger_cs.Models
{
    public class Blog
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string imgUrl { get; set; }
        public bool Published { get; set; }
        public string CreatorId { get; set; }
        public Account Creator { get; set; }
    }
}