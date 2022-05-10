using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Application;

public class ThemeService : ServiceBase<Theme, ThemeDto>, IThemeService
{
    private readonly IThemeRepository _repository;
    private readonly IMapper _mapper;

    public ThemeService(IThemeRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<List<ThemeDto>> FindThemesWithAssignments()
    {
        var themes = await _repository.FindThemesWithAssignments();
        return _mapper.Map<List<ThemeDto>>(themes);
    }


    protected override void UpdateEntityValues(Theme entity, ThemeDto entityDto)
    {
        entity.Url = entityDto.Url;
        entity.ColorPalette = entityDto.ColorPalette;
    }
}