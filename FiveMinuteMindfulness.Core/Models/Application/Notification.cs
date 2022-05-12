using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Models.Application;

public class Notification : AuditEntity
{
    public NotificationType NotificationType { get; set; }
    public string Content { get; set; }
    public DateTime NotificationTime { get; set; }
    public virtual User User { get; set; }
    public Guid UserId { get; set; }
}