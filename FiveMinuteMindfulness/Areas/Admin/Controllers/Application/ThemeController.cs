using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Application;

[Area("Admin")]
[Authorize(Roles = "admin")]
public class ThemesController : Controller
{
    private ILogger<ThemesController> _logger;
    private readonly IThemeService _themeService;
    private readonly UserManager<User> _userManager;
    private readonly IAssignmentService _assignmentService;

    public ThemesController(ILogger<ThemesController> logger,
        UserManager<User> userManager,
        IThemeService themeService,
        IAssignmentService assignmentService)
    {
        _logger = logger;
        _userManager = userManager;
        _themeService = themeService;
        _assignmentService = assignmentService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _themeService.FindThemesWithAssignments());
    }

    public async Task<ViewResult> Create()
    {
        var viewModel = new ThemeDto
        {
            AssignmentDtos = await _assignmentService.GetAllAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ThemeDto model)
    {
        ModelStateRemoval();

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

        var theme = await _themeService.GetByIdAsync((Guid) id);

        if (theme == null)
        {
            return NotFound();
        }

        theme.AssignmentDtos = await _assignmentService.GetAllAsync();

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

        ModelStateRemoval();

        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
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

        var theme = await _themeService.GetByIdAsync((Guid) id);

        if (theme == null)
        {
            return NotFound();
        }

        var user = await _assignmentService.GetByIdAsync(theme.AssignmentId);
        if (user != null)
        {
            theme.Assignment = user;
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

        var user = await _assignmentService.GetByIdAsync(theme.AssignmentId);
        if (user != null)
        {
            theme.Assignment = user;
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


    private void ModelStateRemoval()
    {
        ModelState.Remove("Assignment");
        ModelState.Remove("AssignmentDtos");
    }
}