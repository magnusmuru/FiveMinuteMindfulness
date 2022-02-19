using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FiveMinuteMindfulness.Controllers.Application;

public class ThemeController
{
    private ILogger<ThemeController> _logger;
    private IThemeRepository _themeRepository;

    public ThemeController(ILogger<ThemeController> logger,
        IThemeRepository themeRepository)
    {
        _logger = logger;
        _themeRepository = themeRepository;
    }

    [HttpPost]
    public ActionResult Create(Theme model)
    {
        _themeRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Theme model)
    {
        return new OkObjectResult(_themeRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid themeId, Theme model)
    {
        var theme = await _themeRepository.Find(themeId);

        if (theme != null)
        {
            await _themeRepository.Update(model);
        }
        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid themeId)
    {
        var theme = await _themeRepository.Find(themeId);

        if (theme != null)
        {
            await _themeRepository.Remove(theme);
        }
        return new OkResult();
    }
}