using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class JournalDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal), Name = nameof(Title))]
    public string Title { get; set; }

    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal),
        Name = nameof(Subtitle))]
    public string Subtitle { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal), Name = nameof(Content))]
    public string Content { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal), Name = nameof(User))]
    public UserDto User { get; set; }

    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}