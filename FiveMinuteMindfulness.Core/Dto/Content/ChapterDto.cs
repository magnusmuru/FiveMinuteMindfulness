using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class ChapterDto : BaseDto
{
    [MaxLength(128)] public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public bool IsCompleted { get; set; }
    [DisplayName("Chapter Type")] public ChapterType ChapterType { get; set; }
    public TranscriptionDto? Transcription { get; set; }
    public Guid? TranscriptionId { get; set; }
    public AssignmentDto Assignment { get; set; }
    public Guid AssignmentId { get; set; }
    public List<UserDto>? Users { get; set; }
    public List<AssignmentDto> AssignmentDtos { get; set; }
}