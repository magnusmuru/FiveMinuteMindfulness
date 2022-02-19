using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Controllers.Content;

public class AssignmentController
{
    private ILogger<AssignmentController> _logger;
    private IAssignmentRepository _assignmentRepository;

    public AssignmentController(ILogger<AssignmentController> logger, IAssignmentRepository assignmentRepository)
    {
        _logger = logger;
        _assignmentRepository = assignmentRepository;
    }
    
    [HttpPost]
    public ActionResult Create(Assignment model)
    {
        _assignmentRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Assignment model)
    {
        return new OkObjectResult(_assignmentRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid assignmentId, Assignment model)
    {
        var assignment = await _assignmentRepository.Find(assignmentId);

        if (assignment != null)
        {
            await _assignmentRepository.Update(model);
        }
        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid assignmentId)
    {
        var assignment = await _assignmentRepository.Find(assignmentId);

        if (assignment != null)
        {
            await _assignmentRepository.Remove(assignment);
        }
        return new OkResult();
    }
}