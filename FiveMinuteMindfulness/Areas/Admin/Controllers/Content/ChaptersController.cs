using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Content;

[Area("Admin")]
[Authorize(Roles = "admin")]
public class ChaptersController : Controller
{
    private ILogger<ChaptersController> _logger;
    private readonly IChapterService _chapterService;
    private readonly UserManager<User> _userManager;
    private readonly IAssignmentService _assignmentService;

    public ChaptersController(ILogger<ChaptersController> logger,
        UserManager<User> userManager,
        IChapterService chapterService,
        IAssignmentService assignmentService)
    {
        _logger = logger;
        _userManager = userManager;
        _chapterService = chapterService;
        _assignmentService = assignmentService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _chapterService.FindChaptersWithAssignments());
    }

    public async Task<ViewResult> Create()
    {
        var viewModel = new ChapterDto
        {
            AssignmentDtos = await _assignmentService.GetAllAsync(),
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ChapterDto model)
    {
        ModelStateRemoval();

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

        var chapter = await _chapterService.GetByIdAsync((Guid) id);

        if (chapter == null)
        {
            return NotFound();
        }

        chapter.AssignmentDtos = await _assignmentService.GetAllAsync();

        return View(chapter);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ChapterDto model)
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

        var chapter = await _chapterService.GetByIdAsync((Guid) id);

        if (chapter == null)
        {
            return NotFound();
        }

        var assignment = await _assignmentService.GetByIdAsync(chapter.AssignmentId);
        if (assignment != null)
        {
            chapter.Assignment = assignment;
        }

        return View(chapter);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var chapter = await _chapterService.GetByIdAsync((Guid) id);
        if (chapter == null)
        {
            return NotFound();
        }

        var assignment = await _assignmentService.GetByIdAsync(chapter.AssignmentId);
        if (assignment != null)
        {
            chapter.Assignment = assignment;
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

    private void ModelStateRemoval()
    {
        ModelState.Remove("Assignment");
        ModelState.Remove("AssignmentDtos");
        ModelState.Remove("Transcription");
        ModelState.Remove("TranscriptionId");
        ModelState.Remove("Users");
    }
}