using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Dto.Content;

public class TranscriptionDto : BaseDto
{
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Transcription),
        Name = nameof(Content))]
    public string Content { get; set; }

    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Models.Content.Transcription),
        Name = nameof(Chapter))]
    public ChapterDto Chapter { get; set; }

    public Guid ChapterId { get; set; }
    public List<ChapterDto> ChapterDtos { get; set; }
}