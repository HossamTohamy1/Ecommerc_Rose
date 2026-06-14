using Domain.Enums;
using Domain.Enums.Enums_Models;
using System;

namespace Domain.Models
{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public CouponType Type { get; set; }
        public decimal Value { get; set; }

        public decimal? MinPurchase { get; set; }

        /// <summary>سقف الخصم لو Type = PERCENT</summary>
        public decimal? MaxDiscount { get; set; }

        public int? UsageLimit { get; set; }

        /// <summary>عشان نقدر نطبق UsageLimit فعليًا</summary>
        public int UsedCount { get; set; } = 0;

        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsActive { get; set; } = true;
    }
}