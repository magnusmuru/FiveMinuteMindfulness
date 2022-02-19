using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain.Interfaces;

namespace FiveMinuteMindfulness.Core.Domain;

public abstract class AuditEntity : AuditEntity<Guid>, IEntityWithId
{
}

public abstract class AuditEntity<TKey> : IEntityWithId<TKey>, IEntityAudit where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;
    [MaxLength(32)]
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [MaxLength(32)] 
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}