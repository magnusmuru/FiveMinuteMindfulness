using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Controllers.Content;

public class SectionController
{
    private ILogger<SectionController> _logger;
    private readonly ISectionRepository _sectionRepository;

    public SectionController(ILogger<SectionController> logger,
        ISectionRepository sectionRepository)
    {
        _logger = logger;
        _sectionRepository = sectionRepository;
    }
    
    [HttpPost]
    public ActionResult Create(Section model)
    {
        _sectionRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Section model)
    {
        return new OkObjectResult(_sectionRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid sectionId, Section model)
    {
        var section = await _sectionRepository.Find(sectionId);

        if (section != null)
        {
            await _sectionRepository.Update(model);
        }

        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid sectionId)
    {
        var section = await _sectionRepository.Find(sectionId);

        if (section != null)
        {
            await _sectionRepository.Remove(section);
        }

        return new OkResult();
    }
}