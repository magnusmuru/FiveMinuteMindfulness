using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Enums;
using FiveMinuteMindfulness.Core.Models.Application;

namespace FiveMinuteMindfulness.Core.Models.Content;

public class Assignment : AuditEntity
{
    [MaxLength(128)]
    [Column(TypeName = "jsonb")]
    public LanguageString Title { get; set; }

    [Column(TypeName = "jsonb")] public LanguageString Description { get; set; }
    public string Author { get; set; }
    public List<Chapter?> Chapters { get; set; }
    public List<User?> Users { get; set; }
    public Section Section { get; set; }
    public Guid SectionId { get; set; }
    public Theme? Theme { get; set; }
    public Guid? ThemeId { get; set; }
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }
}