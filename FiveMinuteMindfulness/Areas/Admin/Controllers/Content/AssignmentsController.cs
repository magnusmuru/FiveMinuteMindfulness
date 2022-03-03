using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Content;

[Area("Admin")]
public class AssignmentsController : Controller
{
    private ILogger<AssignmentsController> _logger;
    private readonly IAssignmentService _assignmentService;
    private readonly UserManager<User> _userManager;

    public AssignmentsController(ILogger<AssignmentsController> logger,
        UserManager<User> userManager,
        IAssignmentService assignmentService)
    {
        _logger = logger;
        _userManager = userManager;
        _assignmentService = assignmentService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _assignmentService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Description, Author")] AssignmentDto model)
    {
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _assignmentService.AddAsync(model);
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

        var assignment = await _assignmentService.GetByIdAsync((Guid)id);

        if (assignment == null)
        {
            return NotFound();
        }

        return View(assignment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Title, Description, Author")] AssignmentDto model)
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
            await _assignmentService.UpdateAsync(model);

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

        var meeting = await _assignmentService.GetByIdAsync((Guid)id);

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

        var assignment = await _assignmentService.GetByIdAsync((Guid)id);
        if (assignment == null)
        {
            return NotFound();
        }

        return View(assignment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _assignmentService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}