namespace FiveMinuteMindfulness.Core.Dto;

public class BaseDto : BaseDto<Guid>
{
}

public class BaseDto<TId>
{
    public TId Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}