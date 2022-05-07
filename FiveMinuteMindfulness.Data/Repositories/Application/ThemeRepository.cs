using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories.Application;

public class ThemeRepository : RepositoryBase<Theme>, IThemeRepository
{
    private readonly FiveMinutesContext _context;

    public ThemeRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Theme>> FindThemesWithUsers()
    {
        return await DbSet.Include(x => x.User).ToListAsync();
    }
}