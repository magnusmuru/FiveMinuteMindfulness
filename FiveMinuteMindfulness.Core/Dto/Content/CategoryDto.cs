using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Models;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class CategoryDto : BaseDto
{
    [MaxLength(128, ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Category),
        ErrorMessageResourceName = "MaxLength")]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Category), Name = nameof(Title))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Category),
        ErrorMessageResourceName = "TitleRequired")]
    public LanguageString Title { get; set; }

    public List<AssignmentDto?> Assignments { get; set; }
}