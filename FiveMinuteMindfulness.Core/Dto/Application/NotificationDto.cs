using System.ComponentModel;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class NotificationDto : BaseDto
{
    [DisplayName("Notification Type")]
    public NotificationType NotificationType { get; set; }
    public string Content { get; set; }
    public UserDto User { get; set; }
    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}