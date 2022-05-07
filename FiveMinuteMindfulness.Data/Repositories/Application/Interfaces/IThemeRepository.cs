using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;

public interface IThemeRepository : IRepositoryBase<Theme>
{
    Task<List<Theme>> FindThemesWithUsers();
}