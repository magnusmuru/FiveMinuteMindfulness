using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Enums;

public enum NotificationType
{
    Email = 1,

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Enums.NotificationType), Name = nameof(Push))]
    Push = 2
}