using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class ChapterRepository : RepositoryBase<Chapter>, IChapterRepository
{
    private readonly FiveMinutesContext _context;

    public ChapterRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Chapter>> FindChaptersWithAssignments()
    {
        return await DbSet.Include(x => x.Assignment).Include(x => x.Transcription).ToListAsync();
    }
}