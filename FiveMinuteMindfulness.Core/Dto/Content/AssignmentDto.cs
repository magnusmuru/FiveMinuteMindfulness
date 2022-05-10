using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Enums;
using FiveMinuteMindfulness.Core.Models;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class AssignmentDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Title))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment),
        ErrorMessageResourceName = "TitleRequired")]
    public LanguageString Title { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment),
        Name = nameof(Description))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment),
        ErrorMessageResourceName = "DescriptionRequired")]
    public LanguageString Description { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Author))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment),
        ErrorMessageResourceName = "AuthorRequired")]
    public string Author { get; set; }

    public List<ChapterDto>? Chapters { get; set; }
    public List<UserDto>? Users { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Section))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment),
        ErrorMessageResourceName = "SectionRequired")]
    public SectionDto Section { get; set; }

    public Guid SectionId { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Category))]
    public CategoryDto? Category { get; set; }

    public Guid? CategoryId { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Theme))]
    public ThemeDto? Theme { get; set; }

    public Guid? ThemeId { get; set; }
    public List<CategoryDto> CategoryDtos { get; set; }
    public List<SectionDto> SectionDtos { get; set; }
}