using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Application;

public class Theme : AuditEntity
{
    public string Url { get; set; }
    public string ColorPallete { get; set; }
    public List<User> Users { get; set; }
}