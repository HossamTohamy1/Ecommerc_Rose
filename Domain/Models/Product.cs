using Domain.Enums;
using Domain.Enums.Enums_Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public DiscountType? DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }

        public string Cover { get; set; } = string.Empty;
        public List<string> Gallery { get; set; } = new();

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public Guid? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        // ── Navigation ──────────────────────────────────────────────
        public ICollection<Occasion> Occasions { get; set; } = new List<Occasion>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // ── Computed (NotMapped) ──────────────────────────────────────
        public decimal FinalPrice
        {
            get
            {
                if (DiscountType == null || DiscountValue == null)
                    return Price;

                return DiscountType == Enums.Enums_Models.DiscountType.PERCENT
                    ? Price - (Price * (DiscountValue.Value / 100m))
                    : Math.Max(0, Price - DiscountValue.Value);
            }
        }

        public decimal Rating => Reviews.Any() ? Math.Round((decimal)Reviews.Average(r => r.Rating), 2) : 0;

        public int ReviewsCount => Reviews.Count;
    }
}