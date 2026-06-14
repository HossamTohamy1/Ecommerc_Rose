using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }

        // ── Navigation ──────────────────────────────────────────────
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    public class SubCategory : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}