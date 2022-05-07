using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Application;

public class JournalService : ServiceBase<Journal, JournalDto>, IJournalService
{
    private readonly IJournalRepository _repository;
    private readonly IMapper _mapper;

    public JournalService(IJournalRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<JournalDto>> FindJournalsWithUsers()
    {
        var journals = await _repository.FindJournalsWithUsers();
        return _mapper.Map<List<JournalDto>>(journals);
    }

    protected override void UpdateEntityValues(Journal entity, JournalDto entityDto)
    {
        entity.Content = entityDto.Content;
        entity.Subtitle = entityDto.Subtitle;
        entity.Title = entityDto.Title;
        entity.UserId = entityDto.UserId;
    }
}