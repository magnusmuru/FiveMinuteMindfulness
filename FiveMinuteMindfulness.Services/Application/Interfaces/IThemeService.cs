using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Services.Domain.Interfaces;

namespace FiveMinuteMindfulness.Services.Application.Interfaces;

public interface IThemeService : IServiceBase<ThemeDto>
{
    Task<List<ThemeDto>> FindThemesWithUsers();
}