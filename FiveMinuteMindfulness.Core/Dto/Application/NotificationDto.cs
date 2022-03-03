using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class NotificationDto : BaseDto
{
    public NotificationType NotificationType { get; set; }
    public UserDto User { get; set; }
}