using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class AssignmentDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Title))]
    public string Title { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment),
        Name = nameof(Description))]
    public string Description { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Author))]
    public string Author { get; set; }

    public List<ChapterDto>? Chapters { get; set; }
    public List<UserDto>? Users { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Section))]
    public SectionDto Section { get; set; }

    public Guid SectionId { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Assignment), Name = nameof(Category))]
    public CategoryDto? Category { get; set; }

    public Guid? CategoryId { get; set; }
    public List<CategoryDto> CategoryDtos { get; set; }
    public List<SectionDto> SectionDtos { get; set; }
}