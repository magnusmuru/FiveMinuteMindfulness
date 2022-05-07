using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Models.Content;

public class Chapter : AuditEntity
{
    [MaxLength(128)] public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public bool IsCompleted { get; set; }
    public ChapterType ChapterType { get; set; }
    public Transcription? Transcription { get; set; }
    public Guid? TranscriptionId { get; set; }
    public Assignment Assignment { get; set; }
    public Guid AssignmentId { get; set; }
    public List<User>? Users { get; set; }
}