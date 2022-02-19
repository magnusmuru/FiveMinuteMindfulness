using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Controllers.Content;

public class CategoryController
{
    private ILogger<CategoryController> _logger;
    private ICategoryRepository _categoryRepository;

    public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }
    
    [HttpPost]
    public ActionResult Create(Category model)
    {
        _categoryRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Category model)
    {
        return new OkObjectResult(_categoryRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid categoryId, Category model)
    {
        var category = await _categoryRepository.Find(categoryId);

        if (category != null)
        {
            await _categoryRepository.Update(model);
        }
        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid categoryId)
    {
        var category = await _categoryRepository.Find(categoryId);

        if (category != null)
        {
            await _categoryRepository.Remove(category);
        }
        return new OkResult();
    }
}