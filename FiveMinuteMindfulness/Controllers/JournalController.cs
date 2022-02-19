using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Controllers;

public class JournalController
{
    private ILogger<JournalController> _logger;
    private IJournalRepository _journalRepository;

    public JournalController(ILogger<JournalController> logger,
        IJournalRepository journalRepository)
    {
        _logger = logger;
        _journalRepository = journalRepository;
    }


    [HttpPost]
    public ActionResult Create(Journal model)
    {
        _journalRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Journal model)
    {
        return new OkObjectResult(_journalRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid journalId, Journal model)
    {
        var journal = await _journalRepository.Find(journalId);

        if (journal != null)
        {
            await _journalRepository.Update(model);
        }

        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid journalId)
    {
        var journal = await _journalRepository.Find(journalId);

        if (journal != null)
        {
            await _journalRepository.Remove(journal);
        }

        return new OkResult();
    }
}