using FiveMinuteMindfulness.Areas.Courses.Controllers;
using FiveMinuteMindfulness.Core.Enums;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Content.Controllers;

[Authorize]
[Area("Content")]
public class ContentController : Controller
{
    private ILogger<ContentController> _logger;
    private readonly ISectionService _sectionService;
    private readonly IAssignmentService _assignmentService;

    public ContentController(ILogger<ContentController> logger,
        ISectionService sectionService,
        IAssignmentService assignmentService)
    {
        _logger = logger;
        _sectionService = sectionService;
        _assignmentService = assignmentService;
    }

    public async Task<IActionResult> Index()
    {
        var sections = await _sectionService.FindSectionsWithAssignments();
        sections = sections.Where(x => x.Assignments.Any() && x.ChapterType is ChapterType.Audio or ChapterType.Video)
            .ToList();

        return View(sections);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        var model = await _assignmentService.FindAssignmentsWithCategoriesAndSections();
        return View(model.First(x => x.Id == id));
    }
}