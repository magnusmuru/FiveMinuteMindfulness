using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Services.Domain.Interfaces;

namespace FiveMinuteMindfulness.Services.Content.Interfaces;

public interface ITranscriptionService : IServiceBase<TranscriptionDto>
{
    Task<List<TranscriptionDto>> FindTranscriptionsWithChapters();
}