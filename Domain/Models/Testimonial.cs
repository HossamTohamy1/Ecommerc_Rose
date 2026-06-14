namespace Domain.Models
{
    public class Testimonial : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Image { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}