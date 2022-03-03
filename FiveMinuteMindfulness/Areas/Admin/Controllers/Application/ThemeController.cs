using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Application;

[Area("Admin")]
public class ThemesController : Controller
{
    private ILogger<ThemesController> _logger;
    private readonly IThemeService _themeService;
    private readonly UserManager<User> _userManager;

    public ThemesController(ILogger<ThemesController> logger,
        UserManager<User> userManager,
        IThemeService themeService)
    {
        _logger = logger;
        _userManager = userManager;
        _themeService = themeService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _themeService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Description, Author")] ThemeDto model)
    {
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _themeService.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var theme = await _themeService.GetByIdAsync((Guid)id);

        if (theme == null)
        {
            return NotFound();
        }

        return View(theme);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Title, Description, Author")] ThemeDto model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(userId);
            model.UpdatedBy = Guid.Parse(userId);
            await _themeService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var meeting = await _themeService.GetByIdAsync((Guid)id);

        if (meeting == null)
        {
            return NotFound();
        }

        return View(meeting);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var theme = await _themeService.GetByIdAsync((Guid)id);
        if (theme == null)
        {
            return NotFound();
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