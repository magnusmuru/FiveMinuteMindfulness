using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class CategoryDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Category), Name = nameof(Title))]
    public string Title { get; set; }

    public List<AssignmentDto?> Assignments { get; set; }
}