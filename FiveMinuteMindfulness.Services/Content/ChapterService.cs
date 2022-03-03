using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class ChapterService : ServiceBase<Chapter, ChapterDto>, IChapterService
{
    public ChapterService(IChapterRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Chapter entity, ChapterDto entityDto)
    {
        throw new NotImplementedException();
    }
}