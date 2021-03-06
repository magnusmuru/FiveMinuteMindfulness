using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Services.Domain.Interfaces;

namespace FiveMinuteMindfulness.Services.Content.Interfaces;

public interface IChapterService : IServiceBase<ChapterDto>
{
    Task<List<ChapterDto>> FindChaptersWithAssignments();
}