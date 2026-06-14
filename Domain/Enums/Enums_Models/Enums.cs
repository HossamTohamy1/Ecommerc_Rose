using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums.Enums_Models
{
    public enum Gender
    {
        MALE,
        FEMALE
    }

    public enum UserRole
    {
        USER,
        ADMIN,
        SUPER_ADMIN
    }

    public enum DiscountType
    {
        PERCENT,
        FIXED
    }

    public enum NotificationType
    {
        ORDER,
        PROMOTION,
        SYSTEM,
        REVIEW,
        OTHER
    }

    public enum OrderStatus
    {
        PENDING,
        CONFIRMED,
        PROCESSING,
        SHIPPED,
        DELIVERED,
        CANCELLED,
        REFUNDED
    }

    public enum PaymentStatus
    {
        PENDING,
        PROCESSING,
        SUCCEEDED,
        FAILED,
        REFUNDED,
        CANCELLED
    }

    public enum PaymentMethod
    {
        CREDIT_CARD,
        CASH_ON_DELIVERY
    }

    public enum CouponType
    {
        PERCENT,
        FIXED
    }
}
