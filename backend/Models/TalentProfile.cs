using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TalentProfile
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Bio {  get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ResumeUrl { get; set; }
        public string PortfolioUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        //Navigation Properties
        public User User { get; set; }
    }
}
