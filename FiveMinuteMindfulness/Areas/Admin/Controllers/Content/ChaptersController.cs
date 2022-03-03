using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Content;

[Area("Admin")]
public class ChaptersController : Controller
{
    private ILogger<ChaptersController> _logger;
    private readonly IChapterService _chapterService;
    private readonly UserManager<User> _userManager;

    public ChaptersController(ILogger<ChaptersController> logger,
        UserManager<User> userManager,
        IChapterService chapterService)
    {
        _logger = logger;
        _userManager = userManager;
        _chapterService = chapterService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _chapterService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Description, Author")] ChapterDto model)
    {
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _chapterService.AddAsync(model);
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

        var chapter = await _chapterService.GetByIdAsync((Guid)id);

        if (chapter == null)
        {
            return NotFound();
        }

        return View(chapter);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Title, Description, Author")] ChapterDto model)
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
            await _chapterService.UpdateAsync(model);

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

        var meeting = await _chapterService.GetByIdAsync((Guid)id);

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

        var chapter = await _chapterService.GetByIdAsync((Guid)id);
        if (chapter == null)
        {
            return NotFound();
        }

        return View(chapter);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _chapterService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}