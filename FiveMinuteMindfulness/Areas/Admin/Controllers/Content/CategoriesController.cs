using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Content;

[Area("Admin")]
[Authorize(Roles = "admin")]
public class CategoriesController : Controller
{
    private ILogger<CategoriesController> _logger;
    private readonly ICategoryService _categoryService;
    private readonly UserManager<User> _userManager;

    public CategoriesController(ILogger<CategoriesController> logger,
        UserManager<User> userManager,
        ICategoryService categoryService)
    {
        _logger = logger;
        _userManager = userManager;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _categoryService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryDto model)
    {
        ModelState.Remove("Assignments");
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _categoryService.AddAsync(model);
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

        var category = await _categoryService.GetByIdAsync((Guid) id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, CategoryDto model)
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
            await _categoryService.UpdateAsync(model);

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

        var category = await _categoryService.GetByIdAsync((Guid) id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _categoryService.GetByIdAsync((Guid) id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _categoryService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}