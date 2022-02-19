using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Application;

public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
{
    private readonly FiveMinutesContext _context;

    public NotificationRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}