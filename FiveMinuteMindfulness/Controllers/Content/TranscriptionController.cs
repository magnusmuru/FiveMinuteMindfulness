using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Controllers.Content;

public class TranscriptionController
{
    private ILogger<TranscriptionController> _logger;
    private ITranscriptionRepository _transcriptionRepository;

    public TranscriptionController(ILogger<TranscriptionController> logger, ITranscriptionRepository transcriptionRepository)
    {
        _logger = logger;
        _transcriptionRepository = transcriptionRepository;
    }
    
    [HttpPost]
    public ActionResult Create(Transcription model)
    {
        _transcriptionRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Transcription model)
    {
        return new OkObjectResult(_transcriptionRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid transcriptionId, Transcription model)
    {
        var transcription = await _transcriptionRepository.Find(transcriptionId);

        if (transcription != null)
        {
            await _transcriptionRepository.Update(model);
        }

        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid transcriptionId)
    {
        var transcription = await _transcriptionRepository.Find(transcriptionId);

        if (transcription != null)
        {
            await _transcriptionRepository.Remove(transcription);
        }

        return new OkResult();
    }
}