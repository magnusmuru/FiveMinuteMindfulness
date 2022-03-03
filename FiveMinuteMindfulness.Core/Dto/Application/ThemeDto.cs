namespace FiveMinuteMindfulness.Core.Dto.Application;

public class ThemeDto : BaseDto
{
    public string Url { get; set; }
    public string ColorPalette { get; set; }
    public UserDto User { get; set; }
}