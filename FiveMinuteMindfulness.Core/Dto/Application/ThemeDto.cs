using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;

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

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        Name = nameof(Assignment))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Theme),
        ErrorMessageResourceName = "AssignmentRequired")]
    public AssignmentDto Assignment { get; set; }

    public Guid AssignmentId { get; set; }

    public List<AssignmentDto> AssignmentDtos { get; set; }
}