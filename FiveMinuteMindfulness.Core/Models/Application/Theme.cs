using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Models.Content;

namespace FiveMinuteMindfulness.Core.Models.Application;

public class Theme : AuditEntity
{
    public string Url { get; set; }
    public string ColorPalette { get; set; }
    public Guid AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
}