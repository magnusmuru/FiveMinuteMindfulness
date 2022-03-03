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

    public TranscriptionsController(ILogger<TranscriptionsController> logger,
        UserManager<User> userManager,
        ITranscriptionService transcriptionService)
    {
        _logger = logger;
        _userManager = userManager;
        _transcriptionService = transcriptionService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _transcriptionService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Description, Author")] TranscriptionDto model)
    {
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _transcriptionService.AddAsync(model);
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

        var transcription = await _transcriptionService.GetByIdAsync((Guid)id);

        if (transcription == null)
        {
            return NotFound();
        }

        return View(transcription);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Title, Description, Author")] TranscriptionDto model)
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
            await _transcriptionService.UpdateAsync(model);

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

        var meeting = await _transcriptionService.GetByIdAsync((Guid)id);

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

        var transcription = await _transcriptionService.GetByIdAsync((Guid)id);
        if (transcription == null)
        {
            return NotFound();
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