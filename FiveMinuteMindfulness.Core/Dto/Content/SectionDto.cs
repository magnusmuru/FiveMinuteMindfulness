using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class SectionDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Section), Name = nameof(Title))]
    public string Title { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Section), Name = nameof(Description))]
    public string Description { get; set; }

    public List<AssignmentDto?> Assignments { get; set; }
}