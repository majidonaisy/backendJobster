namespace backend.Models
{
    public class StartupProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Bio {  get; set; }
        public string WebsiteUrl { get; set; }
        public string Location { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; }

        //Navigation Properties
        public User User { get; set; }
    }
}
