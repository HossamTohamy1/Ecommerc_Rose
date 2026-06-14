using System;

namespace Domain.Models
{
    public class AdminAuditLog : BaseEntity
    {
        public Guid AdminId { get; set; }
        public ApplicationUser Admin { get; set; } = null!;

        public string Action { get; set; } = string.Empty;

        public string EntityType { get; set; } = string.Empty;

        public Guid? EntityId { get; set; }

        public string? Changes { get; set; }
    }
}