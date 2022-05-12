using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class NotificationDto : BaseDto
{
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        Name = nameof(NotificationType))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        ErrorMessageResourceName = "NotificationTypeRequired")]
    public NotificationType NotificationType { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        Name = nameof(Content))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        ErrorMessageResourceName = "ContentRequired")]
    public string Content { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        Name = nameof(User))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        ErrorMessageResourceName = "UserRequired")]
    public UserDto User { get; set; }
    
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        Name = nameof(NotificationTime))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Notification),
        ErrorMessageResourceName = "NotificationTimeRequired")]
    [DataType(DataType.DateTime)]
    public DateTime NotificationTime { get; set; }

    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}