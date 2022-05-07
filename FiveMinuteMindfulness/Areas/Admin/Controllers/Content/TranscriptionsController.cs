using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Content;

[Area("Admin")]
public class TranscriptionsController : Controller
{
    private ILogger<TranscriptionsController> _logger;
    private readonly ITranscriptionService _transcriptionService;
    private readonly UserManager<User> _userManager;
    private readonly IChapterService _chapterService;

    public TranscriptionsController(ILogger<TranscriptionsController> logger,
        UserManager<User> userManager,
        ITranscriptionService transcriptionService,
        IChapterService chapterService)
    {
        _logger = logger;
        _userManager = userManager;
        _transcriptionService = transcriptionService;
        _chapterService = chapterService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _transcriptionService.FindTranscriptionsWithChapters());
    }

    public async Task<ViewResult> Create()
    {
        var chapters = await _chapterService.FindChaptersWithAssignments();
        var viewModel = new TranscriptionDto
        {
            ChapterDtos = chapters.Where(x => x.Transcription == null).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TranscriptionDto model)
    {
        var id = _userManager.GetUserId(User);
        model.CreatedBy = Guid.Parse(id);
        model.UpdatedBy = Guid.Parse(id);

        await _transcriptionService.AddAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transcription = await _transcriptionService.GetByIdAsync((Guid) id);

        if (transcription == null)
        {
            return NotFound();
        }

        var chapters = await _chapterService.FindChaptersWithAssignments();

        transcription.ChapterDtos =
            chapters.Where(x => x.TranscriptionId == null || x.Id == transcription.ChapterId).ToList();

        return View(transcription);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, TranscriptionDto model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        var userId = _userManager.GetUserId(User);
        model.UpdatedBy = Guid.Parse(userId);
        await _transcriptionService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transcription = await _transcriptionService.GetByIdAsync((Guid) id);

        if (transcription == null)
        {
            return NotFound();
        }

        var chapter = await _chapterService.GetByIdAsync(transcription.ChapterId);
        if (chapter != null)
        {
            transcription.Chapter = chapter;
        }

        return View(transcription);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transcription = await _transcriptionService.GetByIdAsync((Guid) id);
        if (transcription == null)
        {
            return NotFound();
        }

        var chapter = await _chapterService.GetByIdAsync(transcription.ChapterId);
        if (chapter != null)
        {
            transcription.Chapter = chapter;
        }

        return View(transcription);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _transcriptionService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}