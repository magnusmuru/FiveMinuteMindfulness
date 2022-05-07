using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Application;

public class Theme : AuditEntity
{
    public string Url { get; set; }
    public string ColorPalette { get; set; }
    public virtual User User { get; set; }
    public Guid UserId { get; set; }
}