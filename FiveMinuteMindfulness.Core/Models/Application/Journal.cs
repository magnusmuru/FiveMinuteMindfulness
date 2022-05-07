using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models.Application;

public class Journal : AuditEntity
{
    [MaxLength(128)] 
    public string Title { get; set; }
    [MaxLength(128)]
    public string Subtitle { get; set; }
    public string Content { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}