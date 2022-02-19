using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Application;

public class ThemeRepository : RepositoryBase<Theme>, IThemeRepository
{
    private readonly FiveMinutesContext _context;

    public ThemeRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}