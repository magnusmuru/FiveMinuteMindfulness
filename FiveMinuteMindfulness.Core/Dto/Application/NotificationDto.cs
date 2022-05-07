using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class NotificationDto : BaseDto
{
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        Name = nameof(NotificationType))]
    public NotificationType NotificationType { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        Name = nameof(Content))]
    public string Content { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        Name = nameof(User))]
    public UserDto User { get; set; }

    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}