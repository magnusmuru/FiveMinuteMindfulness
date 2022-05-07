using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;

public interface INotificationRepository : IRepositoryBase<Notification>
{
    Task<List<Notification>> FindNotificationsWithUsers();
}