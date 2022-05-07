using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class ChapterService : ServiceBase<Chapter, ChapterDto>, IChapterService
{
    private readonly IChapterRepository _repository;
    private readonly IMapper _mapper;

    public ChapterService(IChapterRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override void UpdateEntityValues(Chapter entity, ChapterDto entityDto)
    {
        entity.AssignmentId = entityDto.AssignmentId;
        entity.Author = entityDto.Author;
        entity.Description = entityDto.Description;
        entity.ChapterType = entityDto.ChapterType;
        entity.Title = entityDto.Title;
    }

    public async Task<List<ChapterDto>> FindChaptersWithAssignments()
    {
        var chapters = await _repository.FindChaptersWithAssignments();
        return _mapper.Map<List<ChapterDto>>(chapters);
    }
}