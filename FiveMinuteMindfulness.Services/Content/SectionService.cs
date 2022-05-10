using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class SectionService : ServiceBase<Section, SectionDto>, ISectionService
{
    private readonly ISectionRepository _repository;
    private readonly IMapper _mapper;

    public SectionService(ISectionRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override void UpdateEntityValues(Section entity, SectionDto entityDto)
    {
        entity.Description = UpdateLanguageString(entity.Description, entityDto.Description);
        entity.Title = UpdateLanguageString(entity.Title, entityDto.Title);
        entity.ChapterType = entityDto.ChapterType;
    }

    public async Task<List<SectionDto>> FindSectionsWithAssignments()
    {
        var assignments = await _repository.FindSectionsWithAssignments();
        return _mapper.Map<List<SectionDto>>(assignments);
    }
}