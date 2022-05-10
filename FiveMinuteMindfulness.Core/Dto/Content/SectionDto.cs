using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Enums;
using FiveMinuteMindfulness.Core.Models;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class SectionDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Section), Name = nameof(Title))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Section),
        ErrorMessageResourceName = "TitleRequired")]
    public LanguageString Title { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Section), Name = nameof(Description))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Section),
        ErrorMessageResourceName = "DescriptionRequired")]
    public LanguageString Description { get; set; }

    public List<AssignmentDto?> Assignments { get; set; }
    
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(ChapterType))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter),
        ErrorMessageResourceName = "ChapterTypeRequired")]
    public ChapterType ChapterType { get; set; }
}