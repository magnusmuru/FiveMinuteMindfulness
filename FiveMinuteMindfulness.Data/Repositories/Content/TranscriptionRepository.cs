using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class TranscriptionRepository : RepositoryBase<Transcription>, ITranscriptionRepository
{
    private readonly FiveMinutesContext _context;

    public TranscriptionRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Transcription>> FindTranscriptionsWithChapters()
    {
        return await DbSet.Include(x => x.Chapter).ToListAsync();
    }
}