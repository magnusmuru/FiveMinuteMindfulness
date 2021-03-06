using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Enums;

namespace FiveMinuteMindfulness.Core.Models.Content;

public class Section : AuditEntity
{
    [MaxLength(128)]
    [Column(TypeName = "jsonb")]
    public LanguageString Title { get; set; }
    [Column(TypeName = "jsonb")] public LanguageString Description { get; set; }
    public List<Assignment?> Assignments { get; set; }
    public ChapterType ChapterType { get; set; }
}