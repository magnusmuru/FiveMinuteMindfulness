using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Content;

public class Assignment : AuditEntity
{
    [MaxLength(128)] public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public List<Chapter?> Chapters { get; set; }
    public List<User?> Users { get; set; }
    public Section Section { get; set; }
    public Guid SectionId { get; set; }
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }
}