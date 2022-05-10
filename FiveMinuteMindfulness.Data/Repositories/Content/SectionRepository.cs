using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class SectionRepository : RepositoryBase<Section>, ISectionRepository
{
    private readonly FiveMinutesContext _context;

    public SectionRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Section>> FindSectionsWithAssignments()
    {
        return await DbSet
            .Include(x => x.Assignments)
            .ThenInclude(x => x.Theme)
            .Include(x => x.Assignments)
            .ThenInclude(x => x.Chapters)
            .ToListAsync();
    }
}