using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class TranscriptionService : ServiceBase<Transcription, TranscriptionDto>, ITranscriptionService
{
    private readonly ITranscriptionRepository _repository;
    private readonly IMapper _mapper;

    public TranscriptionService(ITranscriptionRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override void UpdateEntityValues(Transcription entity, TranscriptionDto entityDto)
    {
        entity.Content = entityDto.Content;
        entity.ChapterId = entityDto.ChapterId;
    }

    public async Task<List<TranscriptionDto>> FindTranscriptionsWithChapters()
    {
        var transcriptions = await _repository.FindTranscriptionsWithChapters();
        return _mapper.Map<List<TranscriptionDto>>(transcriptions);
    }
}