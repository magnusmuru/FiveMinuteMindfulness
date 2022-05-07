using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories.Application;

public class JournalRepository : RepositoryBase<Journal>, IJournalRepository
{
    private readonly FiveMinutesContext _context;

    public JournalRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Journal>> FindJournalsWithUsers()
    {
        return await DbSet.Include(x => x.User).ToListAsync();
    }
}