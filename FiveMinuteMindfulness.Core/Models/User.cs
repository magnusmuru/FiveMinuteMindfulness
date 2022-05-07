using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Core.Models.Content;

namespace FiveMinuteMindfulness.Core.Models;

public class User : BaseUser
{
    public virtual List<Assignment?> Assignments { get; set; }
    public virtual List<Chapter?> Chapters { get; set; }
    public virtual List<Journal?> Journals { get; set; }
    public virtual List<Notification?> Notifications { get; set; }
    public virtual Theme Theme { get; set; }
    public Guid ThemeId { get; set; }
}