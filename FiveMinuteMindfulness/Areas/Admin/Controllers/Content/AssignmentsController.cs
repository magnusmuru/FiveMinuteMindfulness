using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Content;

[Area("Admin")]
[Authorize(Roles = "admin")]
public class AssignmentsController : Controller
{
    private ILogger<AssignmentsController> _logger;
    private readonly IAssignmentService _assignmentService;
    private readonly UserManager<User> _userManager;
    private readonly ICategoryService _categoryService;
    private readonly ISectionService _sectionService;

    public AssignmentsController(ILogger<AssignmentsController> logger,
        UserManager<User> userManager,
        IAssignmentService assignmentService,
        ICategoryService categoryService,
        ISectionService sectionService)
    {
        _logger = logger;
        _userManager = userManager;
        _assignmentService = assignmentService;
        _categoryService = categoryService;
        _sectionService = sectionService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _assignmentService.FindAssignmentsWithCategoriesAndSections());
    }

    public async Task<ViewResult> Create()
    {
        var viewModel = new AssignmentDto
        {
            CategoryDtos = await _categoryService.GetAllAsync(),
            SectionDtos = await _sectionService.GetAllAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        AssignmentDto model)
    {
        ModelStateRemoval();

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

        var assignment = await _assignmentService.GetByIdAsync((Guid) id);

        if (assignment == null)
        {
            return NotFound();
        }

        assignment.CategoryDtos = await _categoryService.GetAllAsync();
        assignment.SectionDtos = await _sectionService.GetAllAsync();

        return View(assignment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        AssignmentDto model)
    {
        ModelStateRemoval();
        if (ModelState.IsValid)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
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

        var assignment = await _assignmentService.GetByIdAsync((Guid) id);

        if (assignment == null)
        {
            return NotFound();
        }

        var section = await _sectionService.GetByIdAsync(assignment.SectionId);
        if (section != null)
        {
            assignment.Section = section;
        }

        if (assignment.CategoryId != null)
        {
            var category = await _categoryService.GetByIdAsync((Guid) assignment.CategoryId);
            if (category != null)
            {
                assignment.Category = category;
            }
        }

        return View(assignment);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignment = await _assignmentService.GetByIdAsync((Guid) id);
        if (assignment == null)
        {
            return NotFound();
        }

        var section = await _sectionService.GetByIdAsync(assignment.SectionId);
        if (section != null)
        {
            assignment.Section = section;
        }

        if (assignment.CategoryId != null)
        {
            var category = await _categoryService.GetByIdAsync((Guid) assignment.CategoryId);
            if (category != null)
            {
                assignment.Category = category;
            }
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

    private void ModelStateRemoval()
    {
        ModelState.Remove("Chapters");
        ModelState.Remove("Users");
        ModelState.Remove("Section");
        ModelState.Remove("SectionDtos");
        ModelState.Remove("Category");
        ModelState.Remove("CategoryDtos");
        ModelState.Remove("Chapters");
        ModelState.Remove("Theme");
        ModelState.Remove("Users");
        ModelState.Remove("CategoryId");
    }
}