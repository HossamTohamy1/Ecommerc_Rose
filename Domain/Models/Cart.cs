using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem : BaseEntity
    {
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        /// <summary>Snapshot للسعر وقت الإضافة للسلة</summary>
        public decimal PriceAtAdd { get; set; }
    }
}