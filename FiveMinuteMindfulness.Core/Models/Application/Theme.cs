using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Application;

public class Theme : AuditEntity
{
    public string Url { get; set; }
    public string ColorPalette { get; set; }
    public User User { get; set; }
}