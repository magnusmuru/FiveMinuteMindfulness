using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Controllers.Application;

public class NotificationController : Controller
{
    private ILogger<NotificationController> _logger;
    private INotificationRepository _notificationRepository;

    public NotificationController(ILogger<NotificationController> logger,
        INotificationRepository notificationRepository)
    {
        _logger = logger;
        _notificationRepository = notificationRepository;
    }
    
    [HttpPost]
    public ActionResult Create(Notification model)
    {
        _notificationRepository.Add(model);

        return new OkResult();
    }

    [HttpGet]
    public ActionResult Read(Notification model)
    {
        return new OkObjectResult(_notificationRepository.Find(model.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Update(Guid notificationId, Notification model)
    {
        var notification = await _notificationRepository.Find(notificationId);

        if (notification != null)
        {
            await _notificationRepository.Update(model);
        }
        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid notificationId)
    {
        var notification = await _notificationRepository.Find(notificationId);

        if (notification != null)
        {
            await _notificationRepository.Remove(notification);
        }
        return new OkResult();
    }
}