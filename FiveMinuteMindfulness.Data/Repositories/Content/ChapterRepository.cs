using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class ChapterRepository : RepositoryBase<Chapter>, IChapterRepository
{
    private readonly FiveMinutesContext _context;

    public ChapterRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}