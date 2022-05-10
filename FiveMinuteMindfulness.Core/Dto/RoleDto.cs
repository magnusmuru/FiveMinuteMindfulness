using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto;

public class RoleDto : BaseDto
{
    public string Name { get; set; }
    [MinLength(1)]
    [MaxLength(128)]
    public string DisplayName { get; set; } = default!;
}