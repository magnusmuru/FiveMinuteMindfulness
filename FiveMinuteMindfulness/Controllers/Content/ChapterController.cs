using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Controllers.Content;

public class ChapterController
{
    private ILogger<ChapterController> _logger;
    private readonly IChapterRepository _chapterRepository;

    public ChapterController(ILogger<ChapterController> logger, IChapterRepository chapterRepository)
    {
        _logger = logger;
        _chapterRepository = chapterRepository;
    }

    [HttpPost]
    public ActionResult Create(Chapter model)
    {
        _chapterRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Chapter model)
    {
        return new OkObjectResult(_chapterRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid chapterId, Chapter model)
    {
        var chapter = await _chapterRepository.Find(chapterId);

        if (chapter != null)
        {
            await _chapterRepository.Update(model);
        }

        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid chapterId)
    {
        var chapter = await _chapterRepository.Find(chapterId);

        if (chapter != null)
        {
            await _chapterRepository.Remove(chapter);
        }

        return new OkResult();
    }
}