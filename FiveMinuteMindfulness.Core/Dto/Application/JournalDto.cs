using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Application;

public class JournalDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal), Name = nameof(Title))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal),
        ErrorMessageResourceName = "TitleRequired")]
    public string Title { get; set; }

    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal),
        Name = nameof(Subtitle))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal),
        ErrorMessageResourceName = "SubtitleRequired")]
    public string Subtitle { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal), Name = nameof(Content))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal),
        ErrorMessageResourceName = "ContentRequired")]
    public string Content { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal), Name = nameof(User))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Application.Journal),
        ErrorMessageResourceName = "UserRequired")]
    public UserDto User { get; set; }

    public Guid UserId { get; set; }
    public List<UserDto> UserDtos { get; set; }
}