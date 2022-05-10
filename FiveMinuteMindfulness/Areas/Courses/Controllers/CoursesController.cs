using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Enums;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Courses.Controllers;

[Authorize]
[Area("Courses")]
public class CoursesController : Controller
{
    private ILogger<CoursesController> _logger;
    private readonly ISectionService _sectionService;
    private readonly IAssignmentService _assignmentService;

    public CoursesController(ILogger<CoursesController> logger,
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
        sections = sections.Where(x => x.ChapterType == ChapterType.Text && x.Assignments.Any()).ToList();
        sections.Reverse();
        
        return View(sections);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        var model = await _assignmentService.FindAssignmentsWithCategoriesAndSections();
        return View(model.First(x => x.Id == id));
    }
}