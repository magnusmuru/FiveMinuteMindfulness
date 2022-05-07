using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class ThemeDto : BaseDto
{
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        Name = nameof(Url))]
    public string Url { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        Name = nameof(ColorPalette))]
    public string ColorPalette { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme), Name = nameof(User))]
    public UserDto User { get; set; }

    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}