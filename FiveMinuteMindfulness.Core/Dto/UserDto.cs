using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Dto.Content;

namespace FiveMinuteMindfulness.Core.Dto;

public class UserDto : BaseDto
{
    public string Username { get; set; }
    public List<AssignmentDto?> Assignments { get; set; }
    public List<ChapterDto?> Chapters { get; set; }
    public List<JournalDto?> Journals { get; set; }
    public List<NotificationDto?> Notifications { get; set; }
    [MinLength(1)] [MaxLength(128)] public string FirstName { get; set; } = default!;
    [MinLength(1)] [MaxLength(128)] public string LastName { get; set; } = default!;
}