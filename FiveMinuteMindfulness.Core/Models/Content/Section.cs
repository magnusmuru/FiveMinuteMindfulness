using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Content;

public class Section : AuditEntity
{
    [MaxLength(128)] public string Title { get; set; }
    public string Description { get; set; }
    public List<Assignment?> Assignments { get; set; }
}