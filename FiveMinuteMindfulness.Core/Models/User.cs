using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Core.Models.Content;

namespace FiveMinuteMindfulness.Core.Models;

public class User : BaseUser
{
    public List<Assignment>? Assignments { get; set; }
    public List<Chapter>? Chapters { get; set; }
    public List<Journal>? Journals { get; set; }
    public List<Notification>? Notifications { get; set; }
    public Theme? Theme { get; set; }
    public Guid? ThemeId { get; set; }
}