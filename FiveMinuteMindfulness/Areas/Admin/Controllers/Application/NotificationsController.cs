using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Application;

[Area("Admin")]
public class NotificationsController : Controller
{
    private ILogger<NotificationsController> _logger;
    private readonly INotificationService _notificationService;
    private readonly UserManager<User> _userManager;

    public NotificationsController(ILogger<NotificationsController> logger,
        UserManager<User> userManager,
        INotificationService notificationService)
    {
        _logger = logger;
        _userManager = userManager;
        _notificationService = notificationService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _notificationService.GetAllAsync());
    }

    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title, Description, Author")] NotificationDto model)
    {
        if (ModelState.IsValid)
        {
            var id = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(id);
            model.UpdatedBy = Guid.Parse(id);

            await _notificationService.AddAsync(model);
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

        var notification = await _notificationService.GetByIdAsync((Guid)id);

        if (notification == null)
        {
            return NotFound();
        }

        return View(notification);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Title, Description, Author")] NotificationDto model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
            model.CreatedBy = Guid.Parse(userId);
            model.UpdatedBy = Guid.Parse(userId);
            await _notificationService.UpdateAsync(model);

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

        var meeting = await _notificationService.GetByIdAsync((Guid)id);

        if (meeting == null)
        {
            return NotFound();
        }

        return View(meeting);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var notification = await _notificationService.GetByIdAsync((Guid)id);
        if (notification == null)
        {
            return NotFound();
        }

        return View(notification);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (id != Guid.Empty)
        {
            await _notificationService.RemoveAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}