using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Domain;

namespace FiveMinuteMindfulness.Core.Models;

public class Role : BaseRole
{
    [MinLength(1)]
    [MaxLength(128)]
    public string DisplayName { get; set; } = default!;
}