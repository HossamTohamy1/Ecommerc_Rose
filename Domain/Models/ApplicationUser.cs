using Microsoft.AspNetCore.Identity;
using Domain.Enums.Enums_Models;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        // ── Name ────────────────────────────────────────────────────────
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Derived full name — stored for convenience and used in JWT claims.
        /// Kept in sync by the handlers that set FirstName / LastName.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        // ── Profile ─────────────────────────────────────────────────────
        public string? Photo { get; set; }
        public Gender Gender { get; set; }
        public string? CompanyName { get; set; }   // required for ImportOffice
        public string? Address { get; set; }
        public string? Country { get; set; }

        // ── Verification ────────────────────────────────────────────────
        public bool EmailVerified { get; set; } = false;
        public bool PhoneVerified { get; set; } = false;

        // ── Status ──────────────────────────────────────────────────────
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        // ── Audit ───────────────────────────────────────────────────────
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }

        // ── Navigation ──────────────────────────────────────────────────
        public Cart? Cart { get; set; }
        public Wishlist? Wishlist { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<AdminAuditLog> AuditLogs { get; set; } = new List<AdminAuditLog>();
    }
}