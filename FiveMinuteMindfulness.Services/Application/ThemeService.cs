using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Application;

public class ThemeService: ServiceBase<Theme, ThemeDto>, IThemeService
{
    public ThemeService(IThemeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Theme entity, ThemeDto entityDto)
    {
        throw new NotImplementedException();
    }
}