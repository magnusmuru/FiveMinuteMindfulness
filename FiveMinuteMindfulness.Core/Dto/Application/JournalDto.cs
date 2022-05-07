using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class JournalDto : BaseDto
{
    [MaxLength(128)] 
    public string Title { get; set; }
    [MaxLength(128)]
    public string Subtitle { get; set; }
    public string Content { get; set; }
    public UserDto User { get; set; }
    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}