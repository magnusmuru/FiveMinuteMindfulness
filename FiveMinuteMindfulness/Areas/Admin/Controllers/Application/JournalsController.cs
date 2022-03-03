using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Application;

[Area("Admin")]
public class JournalsController : Controller
{
    private ILogger<JournalsController> _logger;
    private readonly IJournalService _journalService;
    private readonly UserManager<User> _userManager;

    public JournalsController(ILogger<JournalsController> logger,
        UserManager<User> userManager,
        IJournalService journalService)
    {
        _logger = logger;
        _userManager = userManager;
        _journalService = journalService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _journalService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Description, Author")] JournalDto model)
    {
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _journalService.AddAsync(model);
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

        var journal = await _journalService.GetByIdAsync((Guid)id);

        if (journal == null)
        {
            return NotFound();
        }

        return View(journal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Title, Description, Author")] JournalDto model)
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
            await _journalService.UpdateAsync(model);

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

        var meeting = await _journalService.GetByIdAsync((Guid)id);

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

        var journal = await _journalService.GetByIdAsync((Guid)id);
        if (journal == null)
        {
            return NotFound();
        }

        return View(journal);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _journalService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}