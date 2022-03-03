using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class TranscriptionService : ServiceBase<Transcription, TranscriptionDto>, ITranscriptionService
{
    public TranscriptionService(ITranscriptionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Transcription entity, TranscriptionDto entityDto)
    {
        throw new NotImplementedException();
    }
}