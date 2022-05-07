using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinuteMindfulness.Areas.Admin.Controllers.Application;

[Area("Admin")]
public class NotificationsController : Controller
{
    private ILogger<NotificationsController> _logger;
    private readonly INotificationService _notificationService;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;

    public NotificationsController(ILogger<NotificationsController> logger,
        UserManager<User> userManager,
        INotificationService notificationService,
        IUserService userService)
    {
        _logger = logger;
        _userManager = userManager;
        _notificationService = notificationService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _notificationService.FindNotificationsWithUsers());
    }

    public async Task<ViewResult> Create()
    {
        var viewModel = new NotificationDto()
        {
            UserDtos = await _userService.GetAllAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        NotificationDto model)
    {
        ModelStateRemoval();

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

        var notification = await _notificationService.GetByIdAsync((Guid) id);

        if (notification == null)
        {
            return NotFound();
        }

        notification.UserDtos = await _userService.GetAllAsync();

        return View(notification);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, NotificationDto model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        ModelStateRemoval();

        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
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

        var notification = await _notificationService.GetByIdAsync((Guid) id);

        if (notification == null)
        {
            return NotFound();
        }

        var user = await _userService.GetByIdAsync(notification.UserId);
        if (user != null)
        {
            notification.User = user;
        }

        return View(notification);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var notification = await _notificationService.GetByIdAsync((Guid) id);
        if (notification == null)
        {
            return NotFound();
        }

        var user = await _userService.GetByIdAsync(notification.UserId);
        if (user != null)
        {
            notification.User = user;
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

    private void ModelStateRemoval()
    {
        ModelState.Remove("User");
        ModelState.Remove("UserDtos");
    }
}