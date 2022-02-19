using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class TranscriptionRepository : RepositoryBase<Transcription>, ITranscriptionRepository
{
    private readonly FiveMinutesContext _context;

    public TranscriptionRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}