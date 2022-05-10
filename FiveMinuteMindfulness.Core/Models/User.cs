using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Core.Models.Content;

namespace FiveMinuteMindfulness.Core.Models;

public class User : BaseUser
{
    public virtual List<Assignment?> Assignments { get; set; }
    public virtual List<Chapter?> Chapters { get; set; }
    public virtual List<Journal?> Journals { get; set; }
    public virtual List<Notification?> Notifications { get; set; }
    [MinLength(1)] [MaxLength(128)] public string FirstName { get; set; } = default!;
    [MinLength(1)] [MaxLength(128)] public string LastName { get; set; } = default!;
    public string FirstLastName => FirstName + " " + LastName;
    public string LastFirstName => LastName + " " + FirstName;
}