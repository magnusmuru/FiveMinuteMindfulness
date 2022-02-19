using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Models.Application;

public class Notification : AuditEntity
{
    public NotificationType NotificationType { get; set; }
    public User User { get; set; }
}