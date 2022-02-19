using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories;

public class JournalRepository : RepositoryBase<Journal>, IJournalRepository
{
    private readonly FiveMinutesContext _context;

    public JournalRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}