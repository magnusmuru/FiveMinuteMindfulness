using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class JournalDto : BaseDto
{
    [MaxLength(128)] 
    public string Title { get; set; }
    public string Content { get; set; }
    public UserDto User { get; set; }
    public Guid UserId { get; set; }
}