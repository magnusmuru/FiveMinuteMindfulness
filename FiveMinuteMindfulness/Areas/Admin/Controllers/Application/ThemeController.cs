using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Application;

[Area("Admin")]
public class ThemesController : Controller
{
    private ILogger<ThemesController> _logger;
    private readonly IThemeService _themeService;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;

    public ThemesController(ILogger<ThemesController> logger,
        UserManager<User> userManager,
        IThemeService themeService,
        IUserService userService)
    {
        _logger = logger;
        _userManager = userManager;
        _themeService = themeService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _themeService.FindThemesWithUsers());
    }

    public async Task<ViewResult> Create()
    {
        var viewModel = new ThemeDto
        {
            UserDtos = await _userService.GetAllAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Url, ColorPalette, UserId")] ThemeDto model)
    {
        var id = _userManager.GetUserId(User);
        model.CreatedBy = Guid.Parse(id);
        model.UpdatedBy = Guid.Parse(id);

        await _themeService.AddAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var theme = await _themeService.GetByIdAsync((Guid) id);

        if (theme == null)
        {
            return NotFound();
        }

        theme.UserDtos = await _userService.GetAllAsync();

        return View(theme);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ThemeDto model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }
        
        var userId = _userManager.GetUserId(User);
        model.UpdatedBy = Guid.Parse(userId);
        await _themeService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var theme = await _themeService.GetByIdAsync((Guid) id);

        if (theme == null)
        {
            return NotFound();
        }

        var user = await _userService.GetByIdAsync(theme.UserId);
        if (user != null)
        {
            theme.User = user;
        }

        return View(theme);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var theme = await _themeService.GetByIdAsync((Guid) id);
        if (theme == null)
        {
            return NotFound();
        }

        var user = await _userService.GetByIdAsync(theme.UserId);
        if (user != null)
        {
            theme.User = user;
        }

        return View(theme);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _themeService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}