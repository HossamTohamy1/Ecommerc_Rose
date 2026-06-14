using System;

namespace Domain.Models
{
    public class Review : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public string Headline { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        /// <summary>1-5</summary>
        public int Rating { get; set; }
    }
}