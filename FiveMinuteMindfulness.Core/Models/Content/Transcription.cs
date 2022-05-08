using System.ComponentModel.DataAnnotations.Schema;
using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Content;

public class Transcription : AuditEntity
{
    [Column(TypeName = "jsonb")] public LanguageString Content { get; set; }
    public Chapter Chapter { get; set; }
    public Guid ChapterId { get; set; }
}