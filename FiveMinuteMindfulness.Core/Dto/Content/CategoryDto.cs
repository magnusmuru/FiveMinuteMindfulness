using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class CategoryDto : BaseDto
{
    [MaxLength(128)] 
    public string Title { get; set; }
    public List<AssignmentDto?> Assignments { get; set; }
}