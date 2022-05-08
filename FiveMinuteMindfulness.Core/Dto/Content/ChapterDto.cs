using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Enums;
using FiveMinuteMindfulness.Core.Models;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class ChapterDto : BaseDto
{
    [MaxLength(128)]
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Title))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter),
        ErrorMessageResourceName = "TitleRequired")]
    public LanguageString Title { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Description))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter),
        ErrorMessageResourceName = "DescriptionRequired")]
    public LanguageString Description { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Author))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter),
        ErrorMessageResourceName = "AuthorRequired")]
    public string Author { get; set; }

    public bool IsCompleted { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(ChapterType))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter),
        ErrorMessageResourceName = "ChapterTypeRequired")]
    public ChapterType ChapterType { get; set; }

    public TranscriptionDto? Transcription { get; set; }
    public Guid? TranscriptionId { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter), Name = nameof(Assignment))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Chapter),
        ErrorMessageResourceName = "AssignmentRequired")]
    public AssignmentDto Assignment { get; set; }

    public Guid AssignmentId { get; set; }
    public List<UserDto>? Users { get; set; }
    public List<AssignmentDto> AssignmentDtos { get; set; }
}