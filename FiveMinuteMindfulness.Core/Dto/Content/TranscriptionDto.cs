namespace FiveMinuteMindfulness.Core.Dto.Content;

public class TranscriptionDto : BaseDto
{
    public string Content { get; set; }
    public ChapterDto Chapter { get; set; }
}