using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Content;

[Area("Admin")]
public class SectionsController : Controller
{
    private ILogger<SectionsController> _logger;
    private readonly ISectionService _sectionService;
    private readonly UserManager<User> _userManager;

    public SectionsController(ILogger<SectionsController> logger,
        UserManager<User> userManager,
        ISectionService sectionService)
    {
        _logger = logger;
        _userManager = userManager;
        _sectionService = sectionService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _sectionService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Description")] SectionDto model)
    {
        ModelState.Remove("Assignments");
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _sectionService.AddAsync(model);
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

        var section = await _sectionService.GetByIdAsync((Guid)id);

        if (section == null)
        {
            return NotFound();
        }

        return View(section);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, SectionDto model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }
        
        ModelState.Remove("Assignments");

        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
            model.UpdatedBy = Guid.Parse(userId);
            await _sectionService.UpdateAsync(model);

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

        var section = await _sectionService.GetByIdAsync((Guid)id);

        if (section == null)
        {
            return NotFound();
        }

        return View(section);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var section = await _sectionService.GetByIdAsync((Guid)id);
        if (section == null)
        {
            return NotFound();
        }

        return View(section);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _sectionService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}