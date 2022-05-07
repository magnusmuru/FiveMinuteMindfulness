using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class ThemeDto : BaseDto
{
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        Name = nameof(Url))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        ErrorMessageResourceName = "UrlRequired")]
    public string Url { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        Name = nameof(ColorPalette))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        ErrorMessageResourceName = "ColorPaletteRequired")]
    public string ColorPalette { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme), Name = nameof(User))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        ErrorMessageResourceName = "UserRequired")]
    public UserDto User { get; set; }

    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}