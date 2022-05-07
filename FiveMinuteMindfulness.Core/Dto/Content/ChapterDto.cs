using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class ChapterDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Title))]
    public string Title { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Description))]
    public string Description { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Author))]
    public string Author { get; set; }

    public bool IsCompleted { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(ChapterType))]
    public ChapterType ChapterType { get; set; }

    public TranscriptionDto? Transcription { get; set; }
    public Guid? TranscriptionId { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Assignment))]
    public AssignmentDto Assignment { get; set; }

    public Guid AssignmentId { get; set; }
    public List<UserDto>? Users { get; set; }
    public List<AssignmentDto> AssignmentDtos { get; set; }
}