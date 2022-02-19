namespace FiveMinuteMindfulness.Core.Domain.Interfaces;

public interface IEntityAudit
{
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}