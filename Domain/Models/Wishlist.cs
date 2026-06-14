using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Wishlist : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public ICollection<WishlistItem> Items { get; set; } = new List<WishlistItem>();
    }

    public class WishlistItem : BaseEntity
    {
        public Guid WishlistId { get; set; }
        public Wishlist Wishlist { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}