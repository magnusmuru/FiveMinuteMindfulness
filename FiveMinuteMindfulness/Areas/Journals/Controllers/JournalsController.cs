using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Journals.Controllers;

[Area("Journals")]
public class JournalsController : Controller
{
    private ILogger<JournalsController> _logger;
    private readonly IJournalService _journalService;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;

    public JournalsController(ILogger<JournalsController> logger,
        UserManager<User> userManager,
        IJournalService journalService,
        IUserService userService)
    {
        _logger = logger;
        _userManager = userManager;
        _journalService = journalService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var journals = await _journalService.FindJournalsWithUsers();
        var userJournals = journals.Where(x => x.UserId == Guid.Parse(_userManager.GetUserId(User)));
        return View(userJournals);
    }

    public async Task<ViewResult> Create()
    {
        var viewModel = new JournalDto
        {
            UserDtos = await _userService.GetAllAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Subtitle, Content")] JournalDto model)
    {
        var userId = _userManager.GetUserId(User);
        model.UserId = Guid.Parse(userId);
        model.CreatedBy = Guid.Parse(userId);
        model.UpdatedBy = Guid.Parse(userId);

        await _journalService.AddAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var journal = await _journalService.GetByIdAsync((Guid) id);

        if (journal == null)
        {
            return NotFound();
        }

        return View(journal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, JournalDto model)
    {
        ModelStateRemoval();

        if (ModelState.IsValid)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            model.UserId = Guid.Parse(userId);
            model.UpdatedBy = Guid.Parse(userId);
            await _journalService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var journal = await _journalService.GetByIdAsync((Guid) id);
        if (journal == null)
        {
            return NotFound();
        }

        var user = await _userService.GetByIdAsync(journal.UserId);
        if (user != null)
        {
            journal.User = user;
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


    private void ModelStateRemoval()
    {
        ModelState.Remove("User");
        ModelState.Remove("UserDtos");
    }
}