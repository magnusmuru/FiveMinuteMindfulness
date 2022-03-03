using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class AssignmentDto : BaseDto
{
    [MaxLength(128)] 
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public List<ChapterDto>? Chapters { get; set; }
    public List<UserDto>? Users { get; set; }
    public List<SectionDto>? Sections { get; set; }
    public CategoryDto? Category { get; set; }
    public Guid? CategoryId { get; set; }
}