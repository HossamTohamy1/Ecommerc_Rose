using Domain.Enums;
using Domain.Enums.Enums_Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public Guid AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        /// <summary>sum قبل الخصم</summary>
        public decimal Subtotal { get; set; }

        /// <summary>الخصم المطبق من الكوبون</summary>
        public decimal Discount { get; set; }

        /// <summary>Subtotal - Discount</summary>
        public decimal Total { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.PENDING;
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CASH_ON_DELIVERY;

        /// <summary>لينك الـ order بالـ payment/refund على Stripe</summary>
        public string? PaymentIntentId { get; set; }

        public string? CouponCode { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Notes { get; set; }
    }

    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        /// <summary>Snapshot لاسم المنتج وقت الطلب</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Snapshot للسعر وقت الطلب</summary>
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}