using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Application;

public class JournalRepository : RepositoryBase<Journal>, IJournalRepository
{
    private readonly FiveMinutesContext _context;

    public JournalRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}