using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class ThemeDto : BaseDto
{
    public string Url { get; set; }
    [DisplayName("Color Palette")]
    public string ColorPalette { get; set; }
    public UserDto User { get; set; }
    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}