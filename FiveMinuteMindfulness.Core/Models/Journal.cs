using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models;

public class Journal : AuditEntity
{
    [MaxLength(128)] 
    public string Title { get; set; }
    public string Content { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}