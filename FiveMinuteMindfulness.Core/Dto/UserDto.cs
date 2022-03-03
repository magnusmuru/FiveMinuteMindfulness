using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Dto.Content;

namespace FiveMinuteMindfulness.Core.Dto;

public class UserDto : BaseDto
{
    public string Name { get; set; }
    public List<AssignmentDto>? Assignments { get; set; }
    public List<ChapterDto>? Chapters { get; set; }
    public List<JournalDto>? Journals { get; set; }
    public List<NotificationDto>? Notifications { get; set; }
    public ThemeDto? Theme { get; set; }
    public Guid? ThemeId { get; set; }
}