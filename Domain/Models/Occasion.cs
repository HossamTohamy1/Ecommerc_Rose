using System.Collections.Generic;

namespace Domain.Models
{
    public class Occasion : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }

        // ── Navigation (M:N) ────────────────────────────────────────
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}