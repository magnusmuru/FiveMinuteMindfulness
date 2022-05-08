using System.ComponentModel.DataAnnotations;
using FiveMinuteMindfulness.Core.Models;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class TranscriptionDto : BaseDto
{
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Transcription),
        Name = nameof(Content))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Transcription),
        ErrorMessageResourceName = "ContentRequired")]
    public LanguageString Content { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Transcription),
        Name = nameof(Chapter))]
    [Required(ErrorMessageResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Transcription),
        ErrorMessageResourceName = "ChapterRequired")]
    public ChapterDto Chapter { get; set; }

    public Guid ChapterId { get; set; }
    public List<ChapterDto> ChapterDtos { get; set; }
}