using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Content;

public class Transcription : AuditEntity
{
    public string Content { get; set; }
    public Chapter Chapter { get; set; }
}